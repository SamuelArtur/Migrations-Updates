using System;
using System.Globalization;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;
using Osb.Core.Platform.Common.Entity;
using Osb.Core.Platform.Business.Service.Models.Result;
using Osb.Core.Platform.Business.Service.Models.Request;
using IntegrationRequest = Osb.Core.Platform.Integration.Entity.FitBank.Models.Request;
using IntegrationResponse = Osb.Core.Platform.Integration.Entity.FitBank.Models.Response;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class AccountMapper : Mapper
    {
        public IntegrationRequest.FindAccountBalanceRequest Map(long accountId, string taxId)
        {
            return new IntegrationRequest.FindAccountBalanceRequest
            {
                AccountId = accountId,
                TaxId = taxId
            };
        }

        public FindAccountBalanceResult Map(IntegrationResponse.FindAccountBalanceResponse response)
        {
            return new FindAccountBalanceResult
            {
                Balance = response.Balance
            };
        }

        public FindAccountDashboardResult Map(IEnumerable<Account> accounts, IntegrationResponse.FindAccountBalanceResponse response)
        {
            return new FindAccountDashboardResult
            {
                Accounts = accounts,
                Balance = response.Balance
            };
        }

        public FindAccountListByLoginRequest Map(FindAccountDashboardRequest request)
        {
            return new FindAccountListByLoginRequest
            {
                Login = request.Login
            };
        }

        public FindAccountListResult Map(IEnumerable<Account> accountList)
        {
            return new FindAccountListResult
            {
                AccountList = accountList
            };
        }

        public IntegrationRequest.FindBankStatementRequest Map(FindBankStatementRequest request)
        {
            return new IntegrationRequest.FindBankStatementRequest
            {
                AccountId = request.AccountId,
                TaxId = request.TaxId,
                Tags = request.Tags,
                OperationType = request.OperationType,
                EndDate = request.EndDate,
                StartDate = request.StartDate,
            };
        }

        public FindBankStatementResult Map(IntegrationResponse.FindBankStatementResponse response)
        {
            List<DayTransactions> transactions = FormatTransactions(response);
            transactions.Reverse();

            return new FindBankStatementResult
            {
                Transactions = transactions
            };
        }

        public IntegrationRequest.FindBankStatementDetailsRequest Map(FindBankStatementDetailsRequest request)
        {

            Method method = request.OperationType switch
            {
                OperationType.InternalTransfer => Method.GetInternalTransferById,
                OperationType.MoneyTransfer => Method.GetMoneyTransferOutById,
                _ => throw new ArgumentOutOfRangeException(nameof(request.OperationType), $"Not expected operation value: {request.OperationType}")
            };

            return new IntegrationRequest.FindBankStatementDetailsRequest
            {
                Method = Enum.GetName(method),
                AccountId = request.AccountId,
                ExternalIdentifier = request.ExternalIdentifier
            };
        }

        public IntegrationRequest.FindBankStatementReceiptRequest Map(FindBankStatementReceiptRequest request)
        {

            Method method = request.OperationType switch
            {
                OperationType.InternalTransfer => Method.GetInternalTransferById,
                OperationType.MoneyTransfer => Method.GetMoneyTransferOutById,
                _ => throw new ArgumentOutOfRangeException(nameof(request.OperationType), $"Not expected operation value: {request.OperationType}")
            };

            return new IntegrationRequest.FindBankStatementReceiptRequest
            {
                Method = Enum.GetName(method),
                AccountId = request.AccountId.Value,
                ExternalIdentifier = request.ExternalIdentifier
            };
        }
        
        public FindBankStatementDetailsResult Map(IntegrationResponse.FindMoneyTransferDetailsResponse response, MoneyTransfer moneyTransfer)
        {
            return new FindBankStatementDetailsResult
            {
                Value = response.Value,
                ToName = response.ToName,
                ToTaxId = response.ToTaxId,
                Date = response.Date,
                Description = response.Description,
                Tags = response.Tags,
                Status = moneyTransfer.Status,
                ExternalIdentifier = moneyTransfer.ExternalIdentifier
            };
        }

        public FindBankStatementDetailsResult Map(IntegrationResponse.FindInternalTransferDetailsResponse response)
        {
            return new FindBankStatementDetailsResult
            {
                Value = response.Value,
                ToName = response.ToName,
                ToTaxId = response.ToTaxId,
                Date = response.Date,
                Description = response.Description,
                Tags = response.Tags,
            };
        }

        public FindBankStatementReceiptResult Map(IntegrationResponse.FindMoneyTransferReceiptResponse response)
        {
            return new FindBankStatementReceiptResult
            {
                Value = response.Value,
                ToName = response.ToName,
                TaxId = response.TaxId,
                Date = response.Date,
                Description = response.Description,
                ControlCode = response.ControlCode,
                ProtocolCode = response.ProtocolCode
            };
        }

        public FindBankStatementReceiptResult Map(IntegrationResponse.FindInternalTransferReceiptResponse response)
        {
            return new FindBankStatementReceiptResult
            {
                Value = response.Value,
                ToName = response.ToName,
                TaxId = response.TaxId,
                Date = response.Date,
                Description = response.Description,
                ControlCode = response.ControlCode,
                ProtocolCode = response.ProtocolCode
            };
        }

        public IntegrationRequest.FindBankStatementMonthlySummaryRequest Map(DateTime? dateMonthly, Account account)
        {
            return new IntegrationRequest.FindBankStatementMonthlySummaryRequest
            {
                AccountId = account.AccountId,
                TaxId = account.TaxId,
                Bank = account.Bank,
                BankBranch = account.BankBranch,
                BankAccount = account.BankAccount,
                BankAccountDigit = account.BankAccountDigit,
                DateMonthly = dateMonthly
            };
        }

        public FindBankStatementMonthlySummaryResult Map(IntegrationResponse.FindBankStatementMonthlySummaryResponse response)
        {
            return new FindBankStatementMonthlySummaryResult
            {
                MoneyInputValue = response.MoneyInputValue,
                MoneyOutputValue = response.MoneyOutputValue
            };
        }

        private List<DayTransactions> FormatTransactions(IntegrationResponse.FindBankStatementResponse response)
        {
            var culture = new CultureInfo("pt-BR");

            var transactions = new List<DayTransactions>();
            var transactionGroups = new Dictionary<string, DayTransactions>();
            decimal currentBalance = 0;

            foreach (var item in response.Transactions)
            {
                if (item.Description != "Saldo Final") currentBalance += item.Value;
                else currentBalance = item.Value;

                int day = item.Date.Day;
                string month = culture.DateTimeFormat.GetAbbreviatedMonthName(item.Date.Month);
                string key = item.Date.ToShortDateString();

                if (!transactionGroups.ContainsKey(key))
                {
                    transactionGroups.Add(key, new DayTransactions
                    {
                        Day = day,
                        Month = month,
                        Balance = currentBalance,
                        Transactions = new List<Models.Result.Transaction>()
                    });
                }
                transactionGroups[key].Balance = currentBalance;
                transactionGroups[key].Transactions.Add(new Models.Result.Transaction
                {
                    Title = item.Description,
                    Establishment = " ",
                    Value = item.Value,
                    ExternalIdentifier = item.ExternalIdentifier,
                    OperationType = item.OperationType
                });
            }

            foreach (var dictionaryItem in transactionGroups)
                transactions.Add(dictionaryItem.Value);

            return transactions;
        }
    }
}