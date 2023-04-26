using System.ComponentModel.DataAnnotations;
using static Transaction_System.UseCases.UserUseCase.Queries.AccountQuery.GetAccount;

namespace Transaction_System.Domain
{
    public class Account : Auditable
    {
        public string Name { get; set; }
        public ICollection<Transaction> ToTransactions { get; set; }
        public ICollection<Transaction> FromTransactions { get; set; }
    }
}
