using ServerMonitor.Config;
using ServerMonitor;

string settingFile = "Setting.txt";
var seeker = new TextSeeker(System.IO.File.ReadAllText(settingFile));

var setting = new Setting();
setting.Load(seeker);


using (var proc = new System.Diagnostics.Process())
{
    var mailSetting = new MailSetting()
    {
        Server = setting.Mail.Server,
        Port = setting.Mail.Port ?? 25,
        To = setting.Mail.To,
        From = setting.Mail.From,
        UserName = setting.Mail.UserName,
        Password = setting.Mail.Password,
        Subject = "====subject5====",
        Body = "Body Mail",
    };
    mailSetting.Save("Sample2.json");


    proc.StartInfo.FileName = "MailTool.exe";
    proc.StartInfo.Arguments = "Sample2.json";
    proc.StartInfo.CreateNoWindow = true;
    proc.StartInfo.UseShellExecute = false;
    proc.Start();
    proc.WaitForExit();
}


Console.ReadLine();
