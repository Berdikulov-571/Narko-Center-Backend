using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.CallCenter;
using NarkoCenter.Domain.Entities.Companies;
using NarkoCenter.Domain.Entities.Doctors;
using NarkoCenter.Domain.Entities.Documents;
using NarkoCenter.Domain.Entities.HospitalNews;
using NarkoCenter.Domain.Entities.Services;
using NarkoCenter.Domain.Entities.Users;

namespace NarkoCenter.Service.Abstractions.DataAccess
{
    public interface IApplicationDbContext
    {
        DbSet<AnswerAndQuestions> AnswerAndQuestions { get; set; }
        DbSet<Help> Helps { get; set; }
        DbSet<Hospital> Hospitals { get; set; }
        DbSet<Doctor> Doctors { get; set; }
        DbSet<Document> Documents { get; set; }
        DbSet<News> News { get; set; }
        DbSet<NarkoCenter.Domain.Entities.Services.Service> Services { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}