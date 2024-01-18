using Microsoft.EntityFrameworkCore;
using NarkoCenter.Domain.Entities.CallCenter;
using NarkoCenter.Domain.Entities.Companies;
using NarkoCenter.Domain.Entities.Doctors;
using NarkoCenter.Domain.Entities.Documents;
using NarkoCenter.Domain.Entities.HospitalNews;
using NarkoCenter.Domain.Entities.Users;
using NarkoCenter.Service.Abstractions.DataAccess;

namespace NarkoCenter.DataAccess.Persistence.DataAccess
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<AnswerAndQuestions> AnswerAndQuestions { get; set; }
        public DbSet<Help> Helps { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Domain.Entities.Services.Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
    }
}