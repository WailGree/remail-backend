using Microsoft.EntityFrameworkCore;
using RemailCore.Models;
using RemailCore.Services;

namespace Remail_backend.Models
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {
        }

        public Account Account { get; set; }
        public MailService MailService { get; set; }
    }
}