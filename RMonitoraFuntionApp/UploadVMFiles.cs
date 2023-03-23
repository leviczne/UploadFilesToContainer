using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace RMonitoraFuntionApp
{
    public class UploadVMFiles
    {
        [FunctionName("UploadVMFiles")]
        public void Run([TimerTrigger("* * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
