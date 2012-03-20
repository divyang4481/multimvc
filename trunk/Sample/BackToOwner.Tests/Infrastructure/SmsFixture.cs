using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackToOwner.Golf.Web.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BackToOwner.Golf.Tests.Infrastructure
{
    [TestClass]
    public class SmsFixture
    {
        //[TestMethod]
        public void CanSendSms()
        {
            ClickatelSmsService smsService = new ClickatelSmsService();
            smsService.Send("32495204340","Hello ce-ci est mon premier sms!");
        }
    }
}
