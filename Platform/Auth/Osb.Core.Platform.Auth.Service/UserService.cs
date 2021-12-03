using Osb.Core.Platform.Auth.Service.Mapping;
using Osb.Core.Platform.Auth.Service.Validators;
using Osb.Core.Platform.Auth.Service.Interfaces;
using Osb.Core.Platform.Auth.Service.Models.Request;
using Osb.Core.Platform.Auth.Repository.Interfaces;
using Osb.Core.Platform.Auth.Factory.Repository.Interfaces;

namespace Osb.Core.Platform.Auth.Service
{
    public class UserService : IUserService
    {
        private readonly UserValidator _validator;
        private readonly UserMapper _mapper;
        private readonly IUserRepositoryFactory _userRepositoryFactory;
        private readonly IUserAccountRepositoryFactory _userAccountRepositoryFactory;

        public UserService(
            IUserRepositoryFactory userRepositoryFactory,
            IUserAccountRepositoryFactory userAccountRepositoryFactory
        )
        {
            _userRepositoryFactory = userRepositoryFactory;
            _userAccountRepositoryFactory = userAccountRepositoryFactory;
            _mapper = new UserMapper();
            _validator = new UserValidator();
        }
        public void Save(UserRequest userRequest)
        {
            _validator.Validate(userRequest);

            // IAccountRepository accountRepository = _accountRepositoryFactory.Create();
            // Account account = accountRepository.GetAccountByTaxId(userRequest.AccountTaxId);

            // if (account == null)
            //     CreateAccount(userRequest);

            // IUserRepository userRepository = _userRepositoryFactory.Create();
            // User user = userRepository.GetUserByLogin(userRequest.UserTaxId);

            // if (user == null)
            //     CreateUser(userRequest);
                
            // IUserAccountRepository userAccountRepository = _userAccountRepositoryFactory.Create();

            // if (userRequest.EventType == 0)
            //     userAccountRepository.InsertUserAccount(account.AccountId, user.UserId);

            // if (userRequest.EventType == 2)
            //     UpdateUserAndAccount(user, account, userRequest);
        }

        private void CreateUser(UserRequest userRequest)
        {
            IUserRepository userRepository = _userRepositoryFactory.Create();
            userRepository.InsertUser(
            userRequest.UserTaxId, userRequest.Name, userRequest.Email, userRequest.CellPhone
            );
        }

        // private void CreateAccount(UserRequest userRequest)
        // {
        //     ICompanyRepository companyRepository = _companyRepositoryFactory.Create();
        //     Company company = companyRepository.GetCompanyById(userRequest.CompanyId);

        //     if (company == null)
        //         throw new OsbAuthException(AuthInfoMsg.INF0001);

        //     IAccountRepository accountRepository = _accountRepositoryFactory.Create();
        //     accountRepository.InsertAccount(
        //       userRequest.CompanyId, userRequest.AccountName,
        //       userRequest.Status, userRequest.Type, userRequest.AccountTaxId
        //     );

        //     IAccountLogRepository accountLogRepository = _accountLogRepositoryFactory.Create();
        //     accountLogRepository.InsertAccountLog(userRequest.AccountTaxId);
        // }

        // private void UpdateUserAndAccount(User userData, Account accountData, UserRequest userRequest)
        // {
        //     IUserRepository userRepository = _userRepositoryFactory.Create();
        //     userRepository.UpdateUser(
        //         userData.UserId, userRequest.UserTaxId, userRequest.Name,
        //         userRequest.Email, userRequest.CellPhone
        //     );

        //     IAccountRepository accountRepository = _accountRepositoryFactory.Create();
        //     accountRepository.UpdateAccount(
        //         accountData.AccountId, userRequest.CompanyId, userRequest.AccountName,
        //         userRequest.Status, userRequest.Type, userRequest.AccountTaxId
        //     );
        // }
    }
}