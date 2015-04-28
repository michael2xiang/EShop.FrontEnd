using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Core.Email
{
    public class EmailServiceFactory
    {
        private static IEmailService _emailService;
        public static void InitEmailService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public static IEmailService GetEmailService()
        {
            return _emailService;
        }
    }
}
