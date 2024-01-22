namespace NarkoCenter.Domain.Entities.CallCenter
{
    public class Help
    {
        public int HelpId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string WhoNeedsHelp { get; set; }
        public string WhatToTreatFor { get; set; }
        public string WhereToPickUp { get; set; }
    }
}