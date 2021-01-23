using DevExpress.Utils.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YZM_3105
{
    public partial class TaskForm : Form
    {
        public TaskForm()
        {
            InitializeComponent();
        }
        public TaskClass task;
        public int projectID = 0;
        WorkFollow workFollow = new WorkFollow();
        private void btnFormClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void cbFill()
        {
            cbTechnicalPerson.DisplayMember = "Name";
            cbTechnicalPerson.ValueMember = null;
            cbTechnicalPerson.DataSource = task.technicalPersons;
        }
        void FormFill()
        {
            tbTaskName.Text = (task.Title == null) ? task.ID.ToString() + " - Task" : task.Title;
            tbTaskNo.Text = task.ID.ToString();
            dateEditTaskDate.DateTime = Convert.ToDateTime(task.Date);
            tbGuessTime.Text = task.GuessTime.ToString();
            tbRealTime.Text = task.RealTime + " Gün";
            tbWorkComment.Text = task.WorkComment;
            tbNotes.Text = task.Note;
            cbFill();
            int technicalPersonIndex = 0;
            foreach (User technicalPerson in cbTechnicalPerson.Items)
            {
                if (technicalPerson.ID == task.TechnicalPersonID)
                {
                    cbTechnicalPerson.SelectedIndex = technicalPersonIndex;
                    break;
                }
                technicalPersonIndex++;
            }
            foreach (WorkFollow workFollow in task.workFollows)
            {
                workFollowTableRowAdd(workFollow);
            }
            workFollowTableRowSort();
        }
        void workFollowTableRowAdd(WorkFollow workFollow)
        {
            tableWorkFollow.Rows.Add(new TablePanelRow(TablePanelEntityStyle.AutoSize, 0));
            tableWorkFollow.Controls.Add(workFollow.ID);
            tableWorkFollow.Controls.Add(workFollow.Date);
            tableWorkFollow.Controls.Add(workFollow.Status);
            tableWorkFollow.Controls.Add(workFollow.Work);
            tableWorkFollow.Controls.Add(workFollow.Comment);
            tableWorkFollow.Controls.Add(workFollow.WorkFollowDeleteButton);
        }
        public void workFollowTableRowSort()
        {
            int row = 1;
            int column = 0;
            for (int i = 6; i < tableWorkFollow.Controls.Count; i++)
            {
                tableWorkFollow.SetCell(tableWorkFollow.Controls[i], row, column);
                column++;
                if (column == 6)
                {
                    row++;
                    column = 0;
                }
            }
        }
        void enabledForm()
        {
            btnFinsihTask.Enabled = false;
            AddWorkFollow.Enabled = false;
            tbTaskName.Enabled = false;
            dateEditTaskDate.Enabled = false;
            cbTechnicalPerson.Enabled = false;
            tbWorkComment.Enabled = false;
            tbNotes.Enabled = false;
            foreach (WorkFollow workFollow in task.workFollows)
            {
                workFollow.ID.Enabled = false;
                workFollow.Date.Enabled = false;
                workFollow.Work.Enabled = false;
                workFollow.Comment.Enabled = false;
                workFollow.WorkFollowDeleteButton.Enabled = false;
            }
        }
        private void TaskForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,0);
            task.GetTechnicalPerson(projectID);
            FormFill();
            this.Name = task.ID.ToString();
            if (task.taskFinish)
            {
                enabledForm();
            }

        }
        private void AddWorkFollow_Click(object sender, EventArgs e)
        {
            if (task.workFollows.Count<=10)
            {
                workFollow = new WorkFollow();
                workFollow.Create(task.ID);
                task.workFollows.Add(workFollow);
                workFollowTableRowAdd(workFollow);
                workFollowTableRowSort();
            }
        }

        private void TaskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            task.Title = tbTaskName.Text;
            task.WorkComment = tbWorkComment.Text;
            task.Note = tbNotes.Text;
            task.TaskButton.Text = task.Title;
            TaskFinishTimeGuess timeGuess = new TaskFinishTimeGuess();
            task.GuessTime = timeGuess.calculateFinishTime(cbTechnicalPerson.Text, tbWorkComment.Text.Length, tbNotes.Text.Length, task.workFollows.Count);
            task.Update();
            
            foreach (WorkFollow workFollow in task.workFollows)
            {
                tableWorkFollow.Controls.Remove(workFollow.ID);
                tableWorkFollow.Controls.Remove(workFollow.Date);
                tableWorkFollow.Controls.Remove(workFollow.Status);
                tableWorkFollow.Controls.Remove(workFollow.Work);
                tableWorkFollow.Controls.Remove(workFollow.Comment);
                tableWorkFollow.Controls.Remove(workFollow.WorkFollowDeleteButton);
            }
        }

        private void tbWorkComment_TextChanged(object sender, EventArgs e)
        {
            lbWorkCommentLetterCounter.Text = tbWorkComment.Text.Length + "/500";
        }

        private void tbNotes_TextChanged(object sender, EventArgs e)
        {
            lbNoteLetterCounter.Text = tbNotes.Text.Length + "/500";
        }

        private void btnTaskDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Task'ı silmek istediğinizden emin misiniz ?", "QUESTİON", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                workFollow.AllWorkFollowDelete(task.ID);
                task.Delete();
                MainForm mainForm = Application.OpenForms["MainForm"] as MainForm;
                foreach (Form Form in mainForm.MdiChildren)
                {
                    if (Form.Name == "ProjectView")
                    {
                        ProjectView projectView = Form as ProjectView;
                        foreach (EventTab eventTab in projectView.Project.eventTabs)
                        {
                            if (eventTab.ID == task.EventTabID)
                            {
                                eventTab.Controls.Remove(task.TaskButton);
                                this.Close();
                            }
                        }
                    }
                }
                foreach (TabControlPanelItem item in mainForm.TabControlPanel.Controls)
                {
                    if (item.Form == this)
                    {
                        item.CloseButton.close();
                    }
                }
            }
        }

        private void cbTechnicalPerson_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbTechnicalPerson.SelectedValue != null)
            {
                User selectedTechnicalPerson = cbTechnicalPerson.SelectedValue as User;
                task.TechnicalPersonID = selectedTechnicalPerson.ID;
                TaskFinishTimeGuess timeGuess = new TaskFinishTimeGuess();
                task.GuessTime = timeGuess.calculateFinishTime(cbTechnicalPerson.Text, tbWorkComment.Text.Length, tbNotes.Text.Length, task.workFollows.Count);
                tbGuessTime.Text = task.GuessTime + " Gün";
            }
        }

        private void btnFinsihTask_Click(object sender, EventArgs e)
        {
            TimeSpan finishTime = DateTime.Today - dateEditTaskDate.DateTime;
            task.RealTime = Math.Abs(Convert.ToInt32(finishTime.TotalDays));
            tbRealTime.Text = task.RealTime + " Gün";
            task.Title = task.Title + "(BİTTİ)";
            tbTaskName.Text = task.Title;
            task.Finish(tbWorkComment.Text.Length,tbNotes.Text.Length);
            task.taskFinish = true;
            enabledForm();
        }
    }
}
