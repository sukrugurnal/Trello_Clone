using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YZM_3105_Test
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void LoginTest()
        {
            YZM_3105.User user = new YZM_3105.User();
            bool result = user.ConnectionQuery("admin", "admin123");
            //beklenen true
            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void RegisterTest()
        {
            YZM_3105.User user = new YZM_3105.User();
            string result = user.NewUserSave("sukru", "123123123", "sfractureg@hotmail.com");
            Assert.AreEqual("Kayıt Başarılı",result);
        }
        [TestMethod]
        public void MailControllerTest()
        {
            YZM_3105.User user = new YZM_3105.User();
            int result = user.UserMailController("sukrugurnal@hotmail.com");
            bool isThere = false;
            if (result>0)
            {
                isThere = true;
            }
            Assert.AreEqual(true, isThere);
        }
    }
}
