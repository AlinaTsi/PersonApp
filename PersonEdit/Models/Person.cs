using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PersonEdit.Models
{
	public class Person
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[DisplayName("First Name")]
		public string FirstName { get; set; }
		[DisplayName("Last Name")]
		public string LastName { get; set; }

	}
}
