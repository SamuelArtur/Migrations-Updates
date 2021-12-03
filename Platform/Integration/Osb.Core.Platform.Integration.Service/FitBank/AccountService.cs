using System.Collections.Generic;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Integration.Util;
using Osb.Core.Platform.Integration.Service.Helpers;
using Osb.Core.Platform.Integration.Entity.Models;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using Osb.Core.Platform.Integration.Entity.Models.Request.Base;
using Osb.Core.Platform.Integration.Factory.Repository.Interfaces;
using Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;
using Osb.Core.Platform.Integration.Entity.FitBank.Models;
using Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using Osb.Core.Platform.Integration.Service.FitBank.Mapping;

namespace Osb.Core.Platform.Integration.Service.FitBank
{
    public class AccountService : IAccountService
    {
        public readonly AccountMapper _mapper = new AccountMapper();
        private readonly RequestHandler _requestHandler = new RequestHandler();
        private readonly ICompanyAuthenticationRepositoryFactory _companyAuthenticationRepositoryFactory;
        private readonly Settings _settings;

        public AccountService(
            ICompanyAuthenticationRepositoryFactory companyAuthenticationRepositoryFactory,
            Settings settings
        )
        {
            _companyAuthenticationRepositoryFactory = companyAuthenticationRepositoryFactory;
            _settings = settings;
        }

        public FindAccountBalanceResponse FindAccountBalance(FindAccountBalanceRequest findAccountBalanceRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findAccountBalanceRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findAccountBalanceRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            FindAccountBalanceResponse response = _mapper.Map<FindAccountBalanceResponse>(externalResponse);
            return response;
        }

        public FindBankStatementResponse FindBankStatement(FindBankStatementRequest findBankStatementRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            ExternalFindBankStatementResponse externalFindBankStatementResponse = _mapper.Map<ExternalFindBankStatementResponse>(externalResponse);
            IEnumerable<Transaction> transactions = _mapper.Map<IEnumerable<Transaction>>(externalFindBankStatementResponse.Transactions);
            FindBankStatementResponse response = FindBankStatementResponse.Create(transactions);

            return response;
        }

        public FindMoneyTransferReceiptResponse FindMoneyTransferReceipt(FindBankStatementReceiptRequest findBankStatementReceiptRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementReceiptRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementReceiptRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);
            ExternalFindBankStatementReceiptResponse externalFindBankStatementReceiptResponse = _mapper.Map<ExternalFindBankStatementReceiptResponse>(externalResponse);

            FindMoneyTransferReceiptResponse response = _mapper.Map<FindMoneyTransferReceiptResponse>(externalFindBankStatementReceiptResponse.MoneyTransfer);
            return response;
        }

        public FindInternalTransferReceiptResponse FindInternalTransferReceipt(FindBankStatementReceiptRequest findBankStatementReceiptRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementReceiptRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementReceiptRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            ExternalFindBankStatementReceiptResponse externalFindBankStatementReceiptResponse = _mapper.Map<ExternalFindBankStatementReceiptResponse>(externalResponse);
            FindInternalTransferReceiptResponse response = _mapper.Map<FindInternalTransferReceiptResponse>(externalFindBankStatementReceiptResponse.InternalTransfer);
            return response;
        }

        public FindMoneyTransferDetailsResponse FindMoneyTransferDetails(FindBankStatementDetailsRequest findtBankStatementDetailsRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findtBankStatementDetailsRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findtBankStatementDetailsRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            ExternalFindBankStatementDetailsResponse externalFindBankStatementDetailsResponse = _mapper.Map<ExternalFindBankStatementDetailsResponse>(externalResponse);
            FindMoneyTransferDetailsResponse response = _mapper.Map<FindMoneyTransferDetailsResponse>(externalFindBankStatementDetailsResponse.MoneyTransfer);

            return response;
        }

        public FindInternalTransferDetailsResponse FindInternalTransferDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementDetailsRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementDetailsRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            ExternalFindBankStatementDetailsResponse externalFindBankStatementDetailsResponse = _mapper.Map<ExternalFindBankStatementDetailsResponse>(externalResponse);
            FindInternalTransferDetailsResponse response = _mapper.Map<FindInternalTransferDetailsResponse>(externalFindBankStatementDetailsResponse.InternalTransfer);

            return response;
        }

        public FindBankStatementMonthlySummaryResponse FindBankStatementMonthlySummary(FindBankStatementMonthlySummaryRequest findBankStatementMonthlySummaryRequest)
        {
            CompanyAuthentication companyAuthentication = CompanyAuthenticationUtil.GetCompanyAuthenticationByAccountId(
                findBankStatementMonthlySummaryRequest.AccountId,
                _companyAuthenticationRepositoryFactory,
                _settings.AesKey,
                _settings.AesIV
            );

            ExternalRequest externalRequest = _mapper.Map(findBankStatementMonthlySummaryRequest, companyAuthentication);
            ExternalResponse externalResponse = _requestHandler.Post(externalRequest);

            ExternalFindBankStatementMonthlySummaryResponse externalFindBankStatementMonthlySummaryResponse = _mapper.Map<ExternalFindBankStatementMonthlySummaryResponse>(externalResponse);
            FindBankStatementMonthlySummaryResponse response = _mapper.Map(externalFindBankStatementMonthlySummaryResponse);
            return response;
        }
    }
}