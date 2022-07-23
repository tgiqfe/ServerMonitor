using ServerMonitor.Config;
using ServerMonitor;

string settingFile = "Setting.txt";
var seeker = new TextSeeker(System.IO.File.ReadAllText(settingFile));

var setting = new Setting();
setting.Load(seeker);





Console.ReadLine();
