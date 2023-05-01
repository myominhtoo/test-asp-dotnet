using System.ComponentModel.DataAnnotations;

namespace BasicCrud.Models
{
    public class Category 
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required!")]
        public string Name { get; set; }

        [Range(minimum:0,maximum:100,ErrorMessage ="Allowed value is 0 to 100!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime UpdatedDateTime { get; set; }
    }
}
