
using System.ComponentModel.DataAnnotations;

namespace Transaction_System.Domain
{
    public class Account : Auditable
    {
        public string Name { get; set; }
        public ICollection<Transaction> Transactions { get; internal set; }
    }
}
