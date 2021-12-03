using System;
using Osb.Core.Platform.Auth.Entity.Models;
using Osb.Core.Platform.Common.Util.Security;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;

namespace Osb.Core.Platform.Auth.Service.Mapping
{
    public class AuthorizationTokenMapper
    {
        public AuthorizationToken Map(long userId, long accountId, long code, long expirationTime)
        {
            string salt = SHA512Provider.GenerateSalt();

            return new AuthorizationToken
            {
                UserId = userId,
                AccountId = accountId,
                Code = SHA512Provider.Encrypt(Convert.ToString(code), salt),
                Salt = salt,
                ExpirationDate = DateTime.Now.AddSeconds(expirationTime),
                Status = AuthorizationTokenStatus.Active
            };
        }

        public AuthorizationToken Map(string code)
        {
            return new AuthorizationToken
            {
                Code = code,
                Status = AuthorizationTokenStatus.Authorized
            };
        }

        public T Map<T>(SendType sendType, long code, long accountId, User user)
        {
            T obj = (T)Activator.CreateInstance(typeof(T));

            if (sendType.Equals(SendType.Mail))
            {
                SendMailRequest sendMailRequest = new SendMailRequest()
                {
                    AccountId = accountId,
                    Subject = "Token",
                    To = user.Mail,
                    Content = Convert.ToString(code)
                };

                obj = (T)Convert.ChangeType(sendMailRequest, typeof(T));
            }
            else if (sendType.Equals(SendType.Sms))
            {
                SendSmsRequest sendSmsRequest = new SendSmsRequest()
                {
                    AccountId = accountId,
                    To = user.CellPhone,
                    Content = Convert.ToString(code)
                };

                obj = (T)Convert.ChangeType(sendSmsRequest, typeof(T));
            }

            return (T)obj;
        }
    }
}