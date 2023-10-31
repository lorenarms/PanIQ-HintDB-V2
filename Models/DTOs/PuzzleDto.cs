using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
	public class PuzzleDto
	{
		public int Id { get; set; }
		public int RoomId { get; set; }
		public string RoomName { get; set; }
		[Required(ErrorMessage = "This puzzle needs a defining name.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "This puzzle needs a description.")]
		public string Description { get; set; }
		[Required, Range(1, int.MaxValue, ErrorMessage = "This must be a positive number")]
		public int Order { get; set; }

	}
}
