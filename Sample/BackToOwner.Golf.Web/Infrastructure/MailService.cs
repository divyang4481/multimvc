using System;
using System.Net.Mail;
using BA.MultiMvc.Framework;
using log4net;

namespace BackToOwner.Golf.Web.Infrastructure
{
    public interface IMailService:ITenantModel
    {
        void SendMail(string to, string from, string text, string subject);

        void SendMail(MailMessage mailMessage);
    }

    public class MailService:IMailService
    {

        public bool MailWasSend { get; private set; }

        #region IMailService Members

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public void SendMail(string to, string from, string text, string subject)
        {
            var message = new MailMessage(from, to)
                              {
                                  Body = text,
                                  IsBodyHtml = true,
                                  Subject = subject
                              };
           this.SendMail(message);
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public void SendMail(MailMessage mailMessage)
        {
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(mailMessage.From.Address, "AP7K2_P`4-ExnrD_ufH>");

            smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            smtpClient.SendAsync(mailMessage, mailMessage.To);
        }

        #endregion

        void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            var mailMessage = sender as IDisposable;
            if (mailMessage!=null)
            {
                mailMessage.Dispose();
            }

            if (e.Cancelled)
            {
                Logger.Error("eMail was not send -" + e.UserState.ToString() + " was cancelled");
                return;
            }
            if (e.Error != null)
            {
                Logger.Error(e.Error.Message);
                return;
            }
            MailWasSend = true;
            Logger.Info("eMail was send successfully to:" + e.UserState.ToString());
        }
    }
}