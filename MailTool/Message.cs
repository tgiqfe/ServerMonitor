
namespace MailTool
{
    internal class Message
    {
        public static void Send(MailSetting setting)
        {
            var msg = new MimeKit.MimeMessage();
            msg.From.Add(new MimeKit.MailboxAddress(null, setting.From));
            setting.To.ToList().ForEach(x => msg.To.Add(new MimeKit.MailboxAddress(null, x)));
            msg.Subject = setting.Subject;

            var bodyText = new MimeKit.TextPart("Plain");
            bodyText.Text = setting.Body;
            msg.Body = bodyText;

            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect(setting.Server, setting.Port, MailKit.Security.SecureSocketOptions.None);
                    if (!string.IsNullOrEmpty(setting.UserName) && !string.IsNullOrEmpty(setting.Password))
                    {
                        client.Authenticate(setting.UserName, setting.Password);
                    }
                    client.Send(msg);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
