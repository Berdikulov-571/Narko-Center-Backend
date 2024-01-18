namespace NarkoCenter.Domain.Dtos.Companies
{
    public class HospitalCreateDto
    {
        public string HospitalName { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string WorkingTime { get; set; } = default!;
        public string Location { get; set; } = default!;
        public int OpenedYear { get; set; } = default!;
        public string? TelegramUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? WContaceUrl { get; set; }
    }
}