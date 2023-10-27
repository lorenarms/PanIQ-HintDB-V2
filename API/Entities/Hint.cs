using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
	public class Hint
	{
		public int Id { get; set; }
		public int PuzzleId { get; set; }
		public int Order { get; set; }
		public string Description { get; set; }

		[ForeignKey("PuzzleId")]
		public Puzzle Puzzle { get; set; }

	}
}
