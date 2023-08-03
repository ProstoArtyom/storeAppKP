using System;
using System.Net;
using System.Net.Mail;

namespace PAS.UI.HelperClasses;

public class EmailHelper
{
    private static Random rand = new();

    public int VerificationCode { get; } = rand.Next(1000, 10000);
    
    public void SendVerificationCode(string emailUser, string loginUser)
    {
        MailAddress fromAddress = new MailAddress("PASApp1234@gmail.com", "PAS App");
        MailAddress toAddress = new MailAddress(emailUser, loginUser);
        MailMessage message = new MailMessage(fromAddress, toAddress);
        message.Body = $"Код подтверждения {VerificationCode}";
        message.Subject = "Регистрация новой учётной записи";

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtp.gmail.com";
        smtpClient.Port = 587;
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.Credentials = new NetworkCredential(fromAddress.Address, "5h~fU3cE'^]_Arg");

        smtpClient.Send(message);
    }
}