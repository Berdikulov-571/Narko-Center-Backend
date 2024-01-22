using MediatR;
using NarkoCenter.Domain.Entities.Admins;

namespace NarkoCenter.Service.UseCases.Admins.Queries
{
    public class GetAdminByIdQuery : IRequest<Admin>
    {
        public int AdminId { get; set; }
    }
}