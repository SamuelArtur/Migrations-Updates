using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Common;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class NotificationService : INotificationService
    {
        public readonly NotificationMapper _mapper = new NotificationMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly Settings _settings;

        public NotificationService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            Settings settings
        )
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _settings = settings;
        }

        public void SendMail(SendMailRequest sendMailRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                sendMailRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(sendMailRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            ExceptionResponse exceptionResponse = _mapper.Map<ExceptionResponse>(externalResponse.Data);
            if (!exceptionResponse.Status)
                throw new OsbIntegrationException(exceptionResponse.Message);
        }

        public void SendSms(SendSmsRequest sendSmsRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
               sendSmsRequest.AccountId,
               _companyAuthenticationRepositoryFactory,
               _settings.AesKey,
               _settings.AesIV
           );

            ExternalRequest externalRequest = _mapper.Map(sendSmsRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            ExceptionResponse exceptionResponse = _mapper.Map<ExceptionResponse>(externalResponse.Data);
            if (!exceptionResponse.Status)
                throw new OsbIntegrationException(exceptionResponse.Message);
        }
    }
}