using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Transaction_System.Shared.Enum;

namespace Transaction_System.Domain
{
    public class Transaction : Auditable
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public TransactionType Type { get; set; }
        public int AttachmentId { get; set; }
        public virtual Attachment? Attachment { get; set; }


        [ForeignKey(nameof(To))]
        public int? ToAccountId { get; set; }
        public virtual Account? To { get; set; }


        [ForeignKey(nameof(From))]
        public int? FromAccountId { get; set; }
        public virtual Account? From { get; set; }

        public virtual ICollection<Attachment>? Attachments { get; set; }
        public virtual ICollection<ApprovalStatus>? ApprovedStatus { get; set; }
    }
}
