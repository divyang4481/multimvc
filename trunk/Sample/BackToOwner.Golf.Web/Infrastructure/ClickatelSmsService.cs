using System;
using BA.MultiMvc.Framework;
using log4net;

namespace BackToOwner.Golf.Web.Infrastructure
{
    public class ClickatelSmsService:ISmsService
    {

        #region ISmsService Members

        public void Send(string number, string text)
        {
            var oSms = new SMS_COMAPILib.SMS();
            var result = oSms.SendSimpleSMS("3351391", "Wilfried.Huybrechts", "T1mnpft.", number, text.Substring(0, text.Length > 160 ? 160 : text.Length));
            if (result.ToLower().StartsWith("err"))
            {
                Logger.Error("SMS ERROR Clickatel API returned:" + result);
            }
            else
            {
                Logger.Info("SMS was succesfully send to:" + number);
            }
        }

        #endregion
    }
}