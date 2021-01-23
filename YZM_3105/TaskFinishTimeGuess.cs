using Microsoft.Extensions.Configuration;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace YZM_3105
{
    public class HousingData
    {
        [LoadColumn(0)]
        public string userName { get; set; }

        [LoadColumn(1)]
        public float taskCommentLength { get; set; }

        [LoadColumn(2)]
        public float taskNoteLength { get; set; }

        [LoadColumn(3)]
        public float taskWorkFollowRowCount { get; set; }
    }
    public class HousingPrediction
    {
        [ColumnName("Score")]
        public float taskFinishTime { get; set; }
    }



    public class TaskFinishTimeGuess
    {
        public int calculateFinishTime(string userName,float commentLength,float noteLength,float workFollowRowCount)
        {
            string connectionString = "Data Source=.;Initial Catalog=Trello_Clone;Integrated Security=True";
            var loaderColumns = new DatabaseLoader.Column[]
            {
                new DatabaseLoader.Column(){Name="taskCommentLength",Type = DbType.Single},
                new DatabaseLoader.Column(){Name="taskNoteLength",Type = DbType.Single},
                new DatabaseLoader.Column(){Name="taskWorkFollowRowCount",Type = DbType.Single},
                new DatabaseLoader.Column(){Name="taskFinishTime",Type = DbType.Single},
                new DatabaseLoader.Column(){Name="userName",Type = DbType.String}
            };
            var connection = new SqlConnection(connectionString);
            var factory = DbProviderFactories.GetFactory(connection);

            var context = new MLContext();

            var loader = context.Data.CreateDatabaseLoader(loaderColumns);

            var dbSource = new DatabaseSource(factory, connectionString,
                "select U.userName,F.taskCommentLength,F.taskNoteLength,F.taskWorkFollowRowCount,F.taskFinishTime from userTable U inner join FinishTime F on U.userID=F.userID");

            var data = loader.Load(dbSource);

            var preview = data.Preview();

            var testTrainSplit = context.Data.TrainTestSplit(data, testFraction: 0.9);

            var pipeline = context.Transforms.Categorical.OneHotEncoding(outputColumnName: "userNameEncoded", inputColumnName: "userName")
                .Append(context.Transforms.Concatenate("Features", "taskCommentLength", "taskNoteLength", "taskWorkFollowRowCount", "userNameEncoded"))
                .Append(context.Regression.Trainers.LbfgsPoissonRegression(labelColumnName: "taskFinishTime"));

            var model = pipeline.Fit(testTrainSplit.TestSet);

            var predictionFunc = context.Model.CreatePredictionEngine<HousingData, HousingPrediction>(model);

            var prediction = predictionFunc.Predict(new HousingData
            {
                userName = userName,
                taskCommentLength = commentLength,
                taskNoteLength = noteLength,
                taskWorkFollowRowCount = workFollowRowCount
            });
            return Convert.ToInt32(prediction.taskFinishTime);
        }
    }
}
