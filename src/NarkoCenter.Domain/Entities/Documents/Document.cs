using NarkoCenter.Domain.Common.BaseEntities;
using NarkoCenter.Domain.Enums.DocumentTypes;

namespace NarkoCenter.Domain.Entities.Documents
{
    public class Document : Auditable
    {
        public int DocumentId { get; set; }
        public string DocumentPath { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}