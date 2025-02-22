using FUNewsManagementSystem.Models;
using FUNewsManagementSystem.Repositories;

namespace FUNewsManagementSystem.Services
{
    public class AccountService
    {
       
            private readonly IAccountRepository _accountRepository;
            private readonly IConfiguration _configuration;

            public AccountService(IAccountRepository accountRepository, IConfiguration configuration)
            {
                _accountRepository = accountRepository;
                _configuration = configuration;
            }

            public async Task<SystemAccount?> AuthenticateUser(string email, string password)
            {

                var adminEmail = _configuration["AdminAccount:Email"];
                var adminPassword = _configuration["AdminAccount:Password"];

                // Kiểm tra nếu là tài khoản admin mặc định
                if (email == adminEmail && password == adminPassword)
                {
                    return new SystemAccount
                    {
                        AccountId = 0,
                        AccountEmail = adminEmail,
                        AccountPassword = adminPassword,
                        AccountRole = 0,
                        AccountName = "Administrator"
                    };
                }


                return await _accountRepository.GetByEmailAndPassword(email, password);
            }
        // Lấy tài khoản theo ID
        public SystemAccount? GetAccountById(short id)
        {
            return _accountRepository.GetAccountById(id);
        }

        // Lấy danh sách tất cả tài khoản
        public IEnumerable<SystemAccount> GetAllAccounts()
        {
            return _accountRepository.GetAllAccount();
        }

        // Thêm tài khoản mới
        public void AddAccount(SystemAccount account)
        {
            _accountRepository.AddAccount(account);
        }

        // Cập nhật tài khoản
        public void UpdateAccount(SystemAccount account)
        {
            _accountRepository.UpdateAccount(account);
        }

        // Xóa tài khoản
        public void DeleteAccount(short id)
        {
            _accountRepository.DeleteAccount(id);
        }
    }
    }

