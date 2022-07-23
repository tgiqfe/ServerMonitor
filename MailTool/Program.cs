
namespace MailTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
#if DEBUG
            /*
            MailSetting setting = new()
            {
                Server = "smtp.example.com",
                Port = 25,
                To = new string[] { "aaaa@sample.com", "bbbb@sample.com", "cccc@sample.com" },
                From = "test@example.com",
                UserName = "test",
                Password = "XXXXXXXX",
                Subject = "====subject====",
                Body = "Mail Body",
            };
            setting.Save("Sample.json");
            
            */

            var debugSetting = MailSetting.Load("Sample.json");
            Message.Send(debugSetting);

            Environment.Exit(0);
#endif

            if (args.Length > 0 && System.IO.File.Exists(args[0]))
            {
                var mailSetting = MailSetting.Load(args[0]);
                Message.Send(mailSetting);
            }
        }
    }
}
