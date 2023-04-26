using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transaction_System.Domain
{
    public class UserCredential
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(Id))]
        public User? User { get; set; }

    }
}
