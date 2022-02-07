using Microsoft.Extensions.Options;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using ProgrammersBlog.Sevices.Abstract;
using ProgrammersBlog.Shared.Utilities.Result.Abstract;
using ProgrammersBlog.Shared.Utilities.Result.Complex_Types;
using ProgrammersBlog.Shared.Utilities.Result.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Sevices.Concreate
{
    public class MailManager : IMailService
    {
        private readonly SmtpSettings _smtpSettings;

        public MailManager(IOptions<SmtpSettings> smtpsettings)
        {
            _smtpSettings = smtpsettings.Value;
        }
        public IResult Send(EmailSendDto emailSendDto)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail),
                To = { new MailAddress(emailSendDto.EMail) },
                Subject = emailSendDto.Subjet,
                IsBodyHtml = true,
                Body = emailSendDto.Message
            };
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(mailMessage);

            return new Result(resultStatus: ResultStatus.Success, $"E-Posta başarı le gönderildi");
        }

        public IResult SendContactEmail(EmailSendDto emailSendDto)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail),
                To = { new MailAddress("cevikburak1@hotmail.com") },
                Subject = emailSendDto.Subjet,
                IsBodyHtml = true,
                Body = $"Gönderen Kişi:{emailSendDto.Name}, Gönderen E-Posta adresi:{emailSendDto.EMail}<br/>{emailSendDto.Message}"
            };
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username,_smtpSettings.Password),
               
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(mailMessage);

            return new Result(resultStatus: ResultStatus.Success, $"E-Posta başarı le gönderildi");
        }
    }
}
