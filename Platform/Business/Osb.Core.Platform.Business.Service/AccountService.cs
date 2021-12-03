using System.Collections.Generic;
using Osb.Core.Platform.Business.Common;
using Osb.Core.Platform.Business.Util.Resources;
using Osb.Core.Platform.Common.Entity;
using System.Linq;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Business.Factory.Repository.Interfaces;
using Osb.Core.Platform.Business.Repository.Interfaces;
using Osb.Core.Platform.Business.Service.Interfaces;
using Osb.Core.Platform.Business.Service.Mapping;
using Osb.Core.Platform.Business.Service.Models.Request;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Validators;
using Osb.Core.Platform.Integration.Factory.Service.Interfaces;
using IntegrationService = Osb.Core.Platform.Integration.Service.FitBank.Interfaces;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Business.Service
{
    public class AccountService : IAccountService
    {
        private readonly AccountValidator _validator;
        private readonly AccountMapper _mapper;
        private readonly IAccountServiceFactory _accountIntegrationServiceFactory;
        private readonly ICompanyRepositoryFactory _companyRepositoryFactory;
        private readonly IAccountRepositoryFactory _accountRepositoryFactory;
        private readonly IAccountLogRepositoryFactory _accountLogRepositoryFactory;
        private readonly ISubAccountRepositoryFactory _subAccountRepositoryFactory;
        private readonly IMoneyTransferRepositoryFactory _moneyTransferRepositoryFactory;

        public AccountService(
            IAccountServiceFactory accountIntegrationServiceFactory,
            ICompanyRepositoryFactory companyRepositoryFactory,
            IAccountRepositoryFactory accountRepositoryFactory,
            IAccountLogRepositoryFactory accountlogRepositoryFactory,
            ISubAccountRepositoryFactory subAccountRepositoryFactory,
            IMoneyTransferRepositoryFactory moneyTransferRepositoryFactory
        )
        {
            _accountIntegrationServiceFactory = accountIntegrationServiceFactory;
            _accountRepositoryFactory = accountRepositoryFactory;
            _accountLogRepositoryFactory = accountlogRepositoryFactory;
            _subAccountRepositoryFactory = subAccountRepositoryFactory;
            _companyRepositoryFactory = companyRepositoryFactory;
            _moneyTransferRepositoryFactory = moneyTransferRepositoryFactory;
            _mapper = new AccountMapper();
            _validator = new AccountValidator();
        }

        public void Save(AccountRequest accountRequest)
        {
            _validator.Validate(accountRequest);

            ICompanyRepository companyRepository = _companyRepositoryFactory.Create();
            Company company = companyRepository.GetCompanyById(accountRequest.CompanyId);

            if (company == null)
                throw new OsbBusinessException(BusinessInfoMsg.INF0005);

            Account account = Account.Create(
                accountRequest.CompanyId,
                accountRequest.Name,
                accountRequest.TaxId,
                accountRequest.Type,
                accountRequest.Status,
                accountRequest.AccountKey,
                CreateSubAccount(
                    accountRequest.Bank,
                    accountRequest.BankBranch,
                    accountRequest.BankAccount,
                    accountRequest.BankAccountDigit)
            );

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            accountRepository.Save(account);
            // IAccountLogRepository accountLogRepository = _accountLogRepositoryFactory.Create();
            // accountLogRepository.InsertAccountLog(accountRequest.TaxId);
        }

        public FindAccountDashboardResult FindAccountDashboard(FindAccountDashboardRequest findAccountDashboardRequest)
        {
            _validator.Validate(findAccountDashboardRequest);

            FindAccountListByLoginRequest findAcountListByLoginRequest = _mapper.Map(findAccountDashboardRequest);
            FindAccountListResult findAcountListByLogindResult = FindAccountListByLogin(findAcountListByLoginRequest);

            var accounts = new List<Account>(findAcountListByLogindResult.AccountList);

            IntegrationRequest.FindAccountBalanceRequest integrationRequest = _mapper.Map(
                accounts[0].AccountId,
                accounts[0].TaxId
            );

            IntegrationService.IAccountService accountIntergrationService = _accountIntegrationServiceFactory.Create();
            IntegrationResponse.FindAccountBalanceResponse getAccountBalanceResponse = accountIntergrationService.FindAccountBalance(integrationRequest);

            FindAccountDashboardResult result = _mapper.Map(accounts, getAccountBalanceResponse);
            return result;
        }

        public FindAccountListResult FindAccountListByLogin(FindAccountListByLoginRequest findAcountListByLoginRequest)
        {
            _validator.Validate(findAcountListByLoginRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            IEnumerable<Account> accountList = accountRepository.GetListByLogin(findAcountListByLoginRequest.Login);

            FindAccountListResult result = _mapper.Map(accountList);
            return result;
        }

        public FindAccountListResult FindAccountListByUserId(long userId)
        {
            _validator.Validate(userId);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            IEnumerable<Account> accountList = accountRepository.GetListByUserId(userId);

            FindAccountListResult result = _mapper.Map(accountList);

            return result;
        }

        public FindAccountBalanceResult FindAccountBalance(FindAccountBalanceRequest findAccountBalanceRequest)
        {
            _validator.Validate(findAccountBalanceRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetByTaxId(findAccountBalanceRequest.TaxId,
                                                           findAccountBalanceRequest.Bank,
                                                           findAccountBalanceRequest.BankBranch,
                                                           findAccountBalanceRequest.BankAccount,
                                                           findAccountBalanceRequest.BankAccountDigit);

            IntegrationRequest.FindAccountBalanceRequest integrationRequest = _mapper.Map(
               account.AccountId,
               findAccountBalanceRequest.TaxId
            );
            IntegrationService.IAccountService accountIntergrationService = _accountIntegrationServiceFactory.Create();
            IntegrationResponse.FindAccountBalanceResponse findAccountBalanceResponse = accountIntergrationService.FindAccountBalance(integrationRequest);

            FindAccountBalanceResult result = _mapper.Map(findAccountBalanceResponse);
            return result;
        }

        public FindBankStatementResult FindBankStatement(FindBankStatementRequest findBankStatementRequest)
        {
            _validator.Validate(findBankStatementRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetByTaxId(findBankStatementRequest.TaxId,
                                                           findBankStatementRequest.Bank,
                                                           findBankStatementRequest.BankBranch,
                                                           findBankStatementRequest.BankAccount,
                                                           findBankStatementRequest.BankAccountDigit);

            IntegrationRequest.FindBankStatementRequest integrationRequest = _mapper.Map(
                findBankStatementRequest
            );

            IntegrationService.IAccountService accountIntergrationService = _accountIntegrationServiceFactory.Create();
            IntegrationResponse.FindBankStatementResponse findBankStatementResponse = accountIntergrationService.FindBankStatement(integrationRequest);

            FindBankStatementResult result = _mapper.Map(findBankStatementResponse);
            return result;
        }

        public FindBankStatementDetailsResult FindBankStatementDetails(FindBankStatementDetailsRequest findBankStatementDetailsRequest)
        {
            _validator.Validate(findBankStatementDetailsRequest);

            IntegrationRequest.FindBankStatementDetailsRequest integrationRequest = _mapper.Map(
                findBankStatementDetailsRequest
            );

            IntegrationService.IAccountService accountIntergrationService = _accountIntegrationServiceFactory.Create();
            FindBankStatementDetailsResult result = new FindBankStatementDetailsResult();

            switch (findBankStatementDetailsRequest.OperationType)
            {
                case OperationType.InternalTransfer:

                    IntegrationResponse.FindInternalTransferDetailsResponse findInternalTransferDetailsResponse = accountIntergrationService.FindInternalTransferDetails(integrationRequest);
                    result = _mapper.Map(findInternalTransferDetailsResponse);
                    break;

                case OperationType.MoneyTransfer:

                    IMoneyTransferRepository moneyTransferRepository = _moneyTransferRepositoryFactory.Create();
                    MoneyTransfer moneyTransferResult = moneyTransferRepository.GetByExternalIdentifier(findBankStatementDetailsRequest.ExternalIdentifier);

                    IntegrationResponse.FindMoneyTransferDetailsResponse findMoneyTransferDetailsResponse = accountIntergrationService.FindMoneyTransferDetails(integrationRequest);
                    result = _mapper.Map(findMoneyTransferDetailsResponse, moneyTransferResult);
                    break;
            }

            return result;
        }

        public FindBankStatementReceiptResult FindBankStatementReceipt(FindBankStatementReceiptRequest findBankStatementReceiptRequest)
        {
            _validator.Validate(findBankStatementReceiptRequest);

            IntegrationRequest.FindBankStatementReceiptRequest integrationRequest = _mapper.Map(
                findBankStatementReceiptRequest
            );

            IntegrationService.IAccountService accountIntegrationService = _accountIntegrationServiceFactory.Create();
            FindBankStatementReceiptResult result = null;

            switch (findBankStatementReceiptRequest.OperationType)
            {
                case OperationType.InternalTransfer:
                    IntegrationResponse.FindInternalTransferReceiptResponse findInternalTransferReceiptResponse = accountIntegrationService.FindInternalTransferReceipt(integrationRequest);
                    result = _mapper.Map(findInternalTransferReceiptResponse);
                    break;

                case OperationType.MoneyTransfer:
                    IntegrationResponse.FindMoneyTransferReceiptResponse findMoneyTransferReceiptResponse = accountIntegrationService.FindMoneyTransferReceipt(integrationRequest);
                    result = _mapper.Map(findMoneyTransferReceiptResponse);
                    break;
            }

            return result;
        }

        public FindBankStatementMonthlySummaryResult FindBankStatementMonthlySummary(FindBankStatementMonthlySummaryRequest findBankStatementMonthlySummaryRequest)
        {
            _validator.Validate(findBankStatementMonthlySummaryRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(findBankStatementMonthlySummaryRequest.AccountId);

            IntegrationRequest.FindBankStatementMonthlySummaryRequest integrationRequest = _mapper.Map(findBankStatementMonthlySummaryRequest.DateMonthly, account);

            IntegrationService.IAccountService accountIntegrationService = _accountIntegrationServiceFactory.Create();
            IntegrationResponse.FindBankStatementMonthlySummaryResponse findBankStatementMonthlySummaryResponse = accountIntegrationService.FindBankStatementMonthlySummary(integrationRequest);

            FindBankStatementMonthlySummaryResult result = _mapper.Map<FindBankStatementMonthlySummaryResult>(findBankStatementMonthlySummaryResponse);
            return result;
        }

        private long? CreateSubAccount(string bank, string bankBranch, string bankAccount, string bankAccountDigit)
        {
            if (string.IsNullOrEmpty(bank))
                return null;

            SubAccount subAccount = SubAccount.Create(bank, bankBranch, bankAccount, bankAccountDigit);
            ISubAccountRepository subAccountRepository = _subAccountRepositoryFactory.Create();
            SubAccount subAccountResult = subAccountRepository.Save(subAccount);

            return subAccountResult.SubAccountId;
        }

        public FindAccountListResult FindAccountListByTaxId(FindAccountListByTaxIdRequest findAccountsByTaxIdRequest)
        {
            _validator.Validate(findAccountsByTaxIdRequest);

            IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            Account account = accountRepository.GetById(findAccountsByTaxIdRequest.AccountId);
            List<Account> accountList = accountRepository.GetByTaxIdAndCompanyId(findAccountsByTaxIdRequest.TaxId, account.CompanyId).ToList();

            accountList.Remove(accountList.SingleOrDefault(x => x.AccountId == findAccountsByTaxIdRequest.AccountId));

            FindAccountListResult result = _mapper.Map(accountList);
            return result;
        }
    }
}