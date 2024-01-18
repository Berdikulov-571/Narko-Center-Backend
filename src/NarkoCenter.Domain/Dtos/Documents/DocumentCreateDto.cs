using NarkoCenter.Domain.Enums.DocumentTypes;

namespace NarkoCenter.Domain.Dtos.Documents
{
    public class DocumentCreateDto
    {
        public string DocumentPath { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}