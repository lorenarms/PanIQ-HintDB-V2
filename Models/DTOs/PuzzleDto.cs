﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
	public class PuzzleDto
	{
		public int Id { get; set; }
		public int RoomId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Order { get; set; }

	}
}
