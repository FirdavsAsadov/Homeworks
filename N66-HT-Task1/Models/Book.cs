using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N66_HT_Task1.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("bookname")]
        [StringLength(50)]
        public string BookName { get; set; } = string.Empty;
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; } = string.Empty;
        [Column("author_id")]
        public int Author_Id { get; set; }
    }
}
