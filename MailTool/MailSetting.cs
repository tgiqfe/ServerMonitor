
namespace MailTool
{
    internal class MailSetting
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string[] To { get; set; }
        public string From { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public static MailSetting Load(string fileName)
        {
            MailSetting setting = null;
            try
            {
                setting = System.Text.Json.JsonSerializer.Deserialize<MailSetting>(
                    System.IO.File.ReadAllText(fileName),
                    new System.Text.Json.JsonSerializerOptions()
                    {
                        WriteIndented = true,
                        IgnoreReadOnlyProperties = true,
                        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                    });
            }
            catch { }
            return setting;
        }

        public void Save(string fileName)
        {
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(
                    this,
                    new System.Text.Json.JsonSerializerOptions()
                    {
                        WriteIndented = true,
                        IgnoreReadOnlyProperties = true,
                        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                    });
                System.IO.File.WriteAllText(fileName, json);
            }
            catch { }
        }
    }
}
