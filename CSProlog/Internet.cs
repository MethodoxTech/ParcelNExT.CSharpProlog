using System;
using System.Net;
using System.Net.Mail;

namespace Prolog
{
    public partial class PrologEngine
    {
        static bool SendMail(string smtpHost, int port, string toAddr, string subject, string body)
        {
            try
            {
                // Set the global callback to always accept the certificate.
                ServicePointManager.ServerCertificateValidationCallback =
                    (sender, certificate, chain, sslPolicyErrors) => true;

                SmtpClient client = new SmtpClient(smtpHost, port)
                {
                    EnableSsl = true
                };

                MailAddress from = new MailAddress("xxxxxx@xxxxxx.xx");
                MailAddress to = new MailAddress(toAddr);
                MailMessage msg = new MailMessage(from, to)
                {
                    Subject = subject,
                    Body = body
                };

                client.Send(msg);
                return true;
            }
            catch (Exception x)
            {
                // Log or handle the exception as needed.
                return false;
            }
        }
    }
}
