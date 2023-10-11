using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
	public class HintDto
	{
		public int Id { get; set; }
		public int PuzzleId { get; set; }
		public int RoomId { get; set; }
		public string Text { get; set; }
		public int Order { get; set; }
	}
}
