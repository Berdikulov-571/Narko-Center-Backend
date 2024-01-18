using NarkoCenter.Domain.Enums.DocumentTypes;

namespace NarkoCenter.Domain.Dtos.Documents
{
    public class DocumentUpdateDto
    {
        public int DocumentId { get; set; }
        public string DocumentPath { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}