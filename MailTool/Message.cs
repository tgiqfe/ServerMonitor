
namespace MailTool
{
    public class Message
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string[] To { get; set; }
        public string From { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public void Send()
        {
            var msg = new MimeKit.MimeMessage();
            msg.From.Add(new MimeKit.MailboxAddress(null, this.From));
            this.To.ToList().ForEach(x => msg.To.Add(new MimeKit.MailboxAddress(null, x)));
            msg.Subject = this.Subject;

            var bodyText = new MimeKit.TextPart("Plain");
            bodyText.Text = this.Body;
            msg.Body = bodyText;

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect(this.Server, this.Port, MailKit.Security.SecureSocketOptions.None);
                if(!string.IsNullOrEmpty(this.UserName) && !string.IsNullOrEmpty(this.Password))
                {
                    client.Authenticate(this.UserName, this.Password);
                }
                client.Send(msg);
                client.Disconnect(true);
            }
        }
    }
}