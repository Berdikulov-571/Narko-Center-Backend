namespace NarkoCenter.Domain.Dtos.CallCenter
{
    public class HelpCreateDto
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string WhoNeedsHelp { get; set; }
        public string WhatToTreatFor { get; set; }
    }
}