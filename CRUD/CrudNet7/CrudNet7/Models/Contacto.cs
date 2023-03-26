using System.ComponentModel.DataAnnotations;

namespace CrudNet7.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please introduce a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please introduce a number phone")]
        public string NumberPhone { get; set; }
        [Required(ErrorMessage = "Please introduce a email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please introduce a type phone")]
        public string TypePhone { get; set; }
    
        public DateTime CreateDate { get; set; }
    }
}
