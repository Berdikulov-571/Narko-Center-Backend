using Microsoft.AspNetCore.Http;

namespace NarkoCenter.Domain.Dtos.Services
{
    public class ServiceUpdateDto
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = default!;
        public decimal PriceADay { get; set; } = default!;
        public int HowManyPeopleThisRoom { get; set; } = default!;
        public int DoctorId { get; set; }
        public IFormFile? IconPath { get; set; }
    }
}