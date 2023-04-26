using System.ComponentModel.DataAnnotations;

namespace Transaction_System.Domain
{
    public abstract class Auditable
    {
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;
    }
}
