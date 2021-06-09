using JobSearchAssistant.Shared;
using JobSearchAssistant.Server.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using Xunit;

namespace JobSearchAssistantTests
{
    public class MailTest
    {
        [Fact]
        public async void SendMail()
        {
            IConfiguration _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("appsettings.Development.json", true, true)
                .Build();

            IOptions<MailSettings> mailSettings = Options.Create<MailSettings>(new MailSettings()
            {
                Host = _config.GetValue<string>("MailSettings:Host"),
                DisplayName = _config.GetValue<string>("MailSettings:DisplayName"),
                Mail = _config.GetValue<string>("MailSettings:Mail"),
                Password = _config.GetValue<string>("MailSettings:Password"),
                Port = _config.GetValue<int>("MailSettings:Port")

        });
            MailService mailService = new MailService(mailSettings);
            await mailService.SendEmailAsync(mailSettings.Value.Mail, "TestTest", "heres another test");

            //add smtp.pop for verification and assert that mail got delivered
        }
    }
}
