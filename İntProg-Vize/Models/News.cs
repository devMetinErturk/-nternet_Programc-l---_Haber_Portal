using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IntProg_Vize.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace İntProg_Vize.Models
{
	public class News
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string NewsName { get; set; }

		[Required]
		public string NewsDescription { get; set; }

		[Required]
		public string NewsPlace { get; set; }

		[Required]
		public string NewsCountry { get; set; }

		[ValidateNever]
		public int NewsTypeId { get; set; }
		[ForeignKey("NewsTypeId")]

		[ValidateNever]
		public NewsType NewsTypeCategory { get; set; }

		[ValidateNever]
		public string ImageUrl { get; set; }
	}
}
