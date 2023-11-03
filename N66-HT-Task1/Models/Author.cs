using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N66_HT_Task1.Models
{
    [Table("Author")]
    public class Author
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("fullname")]
        [StringLength(50)]
        public string FullName { get; set; }
    }
}
