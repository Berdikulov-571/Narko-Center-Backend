using NarkoCenter.Domain.Common.BaseEntities;

namespace NarkoCenter.Domain.Entities.Services
{
    public class Service : Auditable
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = default!;
        public decimal PriceADay { get; set; } = default!;
        public int HowManyPeopleThisRoom { get; set; } = default!;
        public int DoctorId { get; set; }
        public string IconPath { get; set; }
    }
}