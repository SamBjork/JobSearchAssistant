using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobSearchAssistant.Shared
{
    public class Event
    {
        public int Id { get; set; }
        public string CompanyName{ get; set; }
        public string InterviewerName { get; set; }
        public string OtherInfo { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
