using System;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Util.Resources;

namespace Osb.Core.Platform.Business.Service.Validators
{
    public class AccountValidator
    {
        public void Validate(FindAccountDashboardRequest request)
        {
            if (string.IsNullOrEmpty(request.Login))
                throw new OsbBusinessException(BusinessExcMsg.EXC0002);
        }

        public void Validate(FindAccountBalanceRequest request)
        {
            if (string.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(BusinessExcMsg.EXC0005);

            if (request.AccountId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0004);
        }

        public void Validate(FindBankStatementRequest request)
        {
            if (string.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(BusinessExcMsg.EXC0005);

            if (request.AccountId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0004);

            if (request.StartDate == null)
                throw new OsbBusinessException(BusinessExcMsg.EXC0006);

            if (request.EndDate == null)
                throw new OsbBusinessException(BusinessExcMsg.EXC0007);
        }

        public void Validate(FindBankStatementDetailsRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0004);

            if (!Enum.IsDefined(typeof(OperationType), request.OperationType))
                throw new OsbBusinessException(BusinessExcMsg.EXC0003);
        }

        public void Validate(FindBankStatementReceiptRequest request)
        {
            if (request.AccountId == null || request.AccountId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0004);

            if (string.IsNullOrEmpty(request.ExternalIdentifier))
                throw new OsbBusinessException(BusinessExcMsg.EXC0001);

            if (!Enum.IsDefined(typeof(OperationType), request.OperationType))
                throw new OsbBusinessException(BusinessExcMsg.EXC0003);
        }

        public void Validate(AccountRequest request)
        {
            if (string.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(BusinessExcMsg.EXC0005);

            if (string.IsNullOrEmpty(request.Name))
                throw new OsbBusinessException(BusinessExcMsg.EXC0023);

            if (request.Type == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0016);

            if (request.Status == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0030);
        }

        public void Validate(FindAccountListByLoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Login))
                 throw new OsbBusinessException(BusinessExcMsg.EXC0002);
        }

          public void Validate(long userId)
        {
            if (userId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0045);
        }

        public void Validate(FindBankStatementMonthlySummaryRequest request)
        {
            if (request.DateMonthly == null)
                throw new OsbBusinessException("Campo de data obrigatório.");
        }

        public void Validate(FindAccountListByTaxIdRequest request)
        {
            if (request.AccountId == 0)
                throw new OsbBusinessException(BusinessExcMsg.EXC0004);

            if (string.IsNullOrEmpty(request.TaxId))
                throw new OsbBusinessException(BusinessExcMsg.EXC0005);
        }
    }
}