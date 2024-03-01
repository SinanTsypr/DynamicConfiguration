using SecilStore.ApplicationCore.Entities;
using SecilStore.Infrastructure.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecilStore.ConfigurationReader
{
    public class ConfigurationReader : HostedService
    {
        private ConfigurationRepository ConfigurationRepository { get; set; }

        public ConfigurationReader(string applicationName, string connectionString, int refreshTimerIntervalInMs)
        {
            ApplicationName = applicationName;
            ConnectionString = connectionString;
            RefreshTimerIntervalInMs = refreshTimerIntervalInMs;

            this.ConfigurationRepository = new ConfigurationRepository(connectionString, "configuration", "configurations");

            this.StartAsync(new CancellationToken());
        }

        private string docPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ApplicationName + "-dynamic-configuration.json");
            }
        }

        private string ApplicationName { get; set; }
        private string ConnectionString { get; set; }
        private int RefreshTimerIntervalInMs { get; set; }

        private List<Configuration> Configurations { get; set; }

        private async Task GetRecords()
        {
            try
            {
                Configurations = ConfigurationRepository.GetListByApplicationName(ApplicationName);
                WriteToFile();
            }
            catch (Exception ex)
            {
                ReadFromFile();
            }

        }

        private void WriteToFile()
        {
            using (StreamWriter outputFile = new StreamWriter(docPath))
            {
                outputFile.Write(JsonConvert.SerializeObject(Configurations));
            }
        }

        private void ReadFromFile()
        {
            FileStream fileStream = new FileStream(docPath, FileMode.Open);
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string records = reader.ReadToEnd();
                Configurations = JsonConvert.DeserializeObject<List<Configuration>>(records);
            }
        }

        public T GetValue<T>(string key)
        {
            var item = Configurations.Find(r => r.Name == key && r.IsActive);
            if (item == null)
            {
                return default(T);
            }
            return (T)Convert.ChangeType(item.Value, typeof(T));
        }

        protected override async Task ExecuteAsync(CancellationToken cToken)
        {
            while (!cToken.IsCancellationRequested)
            {
                GetRecords();
                await Task.Delay(RefreshTimerIntervalInMs, cToken);
            }

        }
    }
}
