﻿
namespace EShop.FrontEnd.Core.Email
{
    public interface IEmailService
    {
        void SendMail(string from, string to, string subject, string body);
    }
}
