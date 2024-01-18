using Microsoft.AspNetCore.Http;
using NarkoCenter.Domain.Enums.DocumentTypes;

namespace NarkoCenter.Domain.Dtos.Documents
{
    public class DocumentCreateDto
    {
        public IFormFile DocumentPath { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}