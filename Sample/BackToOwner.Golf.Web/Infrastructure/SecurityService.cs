using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace BackToOwner.Golf.Web.Infrastructure
{
    public class SecurityService:ISecurityService
    {

       protected virtual string CreateSalt(int size)
        {
            //Generate a cryptographic random number.
            var buff = new byte[size];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buff);
            }
           // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(buff);
        }

       public virtual string Hash(string password, out string passwordSalt)
       {
           passwordSalt = CreateSalt(10);
           return Hash(password, passwordSalt);
       }

       public virtual string Hash(string password, string passwordSalt)
       {
           string saltAndPwd = String.Concat(password, passwordSalt);
           string hashedPwd =
               FormsAuthentication.HashPasswordForStoringInConfigFile(
           saltAndPwd, "sha1");

           return hashedPwd;
       }

        public void SetAuthenticationCookie(string userId, bool remember)
        {
            FormsAuthentication.SetAuthCookie(userId, remember);
        }

        public string GenerateRandomPaswword()
        {
            return Generator.RandomString(8);
        }

        public static class Generator
        {
            private static Random _random = new Random();


            public static string RandomString(int size)
            {
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < size; i++)
                {
                    //26 letters in the alfabet, ascii + 65 for the capital letters
                    if (_random.NextDouble()>0.3846153846153846)
                        builder.Append(Convert.ToChar(Convert.ToInt32(Math.Floor(26 * _random.NextDouble() + 65))));
                    else
                        builder.Append(Convert.ToInt32(Math.Floor(10 * _random.NextDouble())));

                }
                return builder.ToString();
            }
        }

        public string Identity
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }


        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }


        protected IDictionary<string,int> FailureAudits
        {
            get
            {
                lock (this)
                {
                    string key = "FailureAudits";
                    if (HttpRuntime.Cache[key] == null)
                    {
                        HttpRuntime.Cache.Add(
                           key,
                           new Dictionary<string, int>(),
                           null,
                           DateTime.Now.AddSeconds(3600),
                           System.Web.Caching.Cache.NoSlidingExpiration,
                           System.Web.Caching.CacheItemPriority.Normal,
                           null
                           );
                    }

                    return (IDictionary<string, int>)HttpRuntime.Cache[key];  
                }
            }
        }

        private void ensureKeyExist(string ip)
        {
            if (!FailureAudits.ContainsKey(ip)) FailureAudits.Add(ip,0);
        }

        public bool IsRequestorBlackListed(string requestorIp)
        {
            this.ensureKeyExist(requestorIp);
            return FailureAudits[requestorIp] > 10;
        }

        public void AuditFailure(string ip)
        {
            this.ensureKeyExist(ip);
            FailureAudits[ip]++;
        }

        public void AuditSuccess(string ip)
        {
            this.ensureKeyExist(ip);
            FailureAudits[ip] = 0;
        }
    }
}