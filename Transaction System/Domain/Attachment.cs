using System.ComponentModel.DataAnnotations.Schema;

namespace Transaction_System.Domain
{
    public class Attachment : Auditable
    {
        public string? ImageUrl { get; set; }
        public int TransactionId { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
