using BackToOwner.Golf.Web.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackToOwner.Golf.Tests.Infrastructure
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MailFixture
    {
        [TestMethod]
        public void SendMail()
        {
            MailService mailService = new MailService();
            mailService.SendMail("gvd8@hotmail.com","golflabel@golflabel.net", "this is a test", "test mail GolfLabel.net");

            for (int i = 0; i < 10; i++)
            {
                if (mailService.MailWasSend)
                    return;
                System.Threading.Thread.Sleep(500);
            }
            Assert.IsTrue(mailService.MailWasSend);
        }
    }
}
