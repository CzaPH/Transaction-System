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

        
        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        
        [ForeignKey(nameof(From))]
        public int FromId { get; set; }
        public virtual Account From { get; set; }

    }
}
