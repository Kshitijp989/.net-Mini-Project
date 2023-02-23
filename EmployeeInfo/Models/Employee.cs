using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="* Name cannot be blank")]
        public string Name { get; set; }
        [Required(ErrorMessage = "* City cannot be blank")]
        public string City { get; set; }
        [Required(ErrorMessage = "* State cannot be blank")]
        public string State { get; set; }
        [Required]
        public decimal? Salary { get; set; }

    }
}
