using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchAssistant.Server.Services
{
    public class CurrentYearService
    {
        public string GetCurrentYear()
        {
            var dateTime = DateTime.Today.Year.ToString();
            return dateTime;
        }
    }
}
