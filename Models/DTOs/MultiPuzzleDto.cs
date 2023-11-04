using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
	public class MultiPuzzleDto
	{
		public int roomId { get; set; }
		public List<PuzzleDto> NewPuzzlesToAdd = new List<PuzzleDto>();

	}
}
