using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task1ASP.Models
{
	//TODO Название не очень
	//TODO Атрибуты повесь на свойства
	public class Questionnaire
	{
		public int Id { get; set; }

		public string About { get; set; }

		[Range(0, 100, ErrorMessage = "Enter correct data")]
		public int Age { get; set; }

		public string Eye { get; set; }

		public virtual ICollection<string> Animals { get; set; }
	}
}