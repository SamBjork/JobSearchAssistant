using System;

namespace JobSearchAssistant.Shared
{
    public class Job
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Status { get; set; }
        public string Position { get; set; }
        public DateTime AppliedDate { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
