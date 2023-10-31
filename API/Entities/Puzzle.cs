using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
	public class Puzzle
	{
		public int Id { get; set; }
		public int RoomId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }

		[ForeignKey("RoomId")]
		public Room Room { get; set; }


	}
}
