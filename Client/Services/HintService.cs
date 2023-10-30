using System.Net.Http.Json;
using Client.Services.Contracts;
using Models.DTOs;

namespace Client.Services
{
	public class HintService : IHintService
	{
		private readonly HttpClient _httpClient;

		public HintService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}


		public async Task<IEnumerable<HintDto>> GetHints(int puzzleId)
		{
			var response = await _httpClient.GetAsync($"api/Hint/{puzzleId}");

			if (response.IsSuccessStatusCode)
			{
				if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
				{
					return Enumerable.Empty<HintDto>();
				}

				return await response.Content.ReadFromJsonAsync<IEnumerable<HintDto>>();
			}

			var message = await response.Content.ReadAsStringAsync();
			throw new Exception(message);
		}

		public async Task<IEnumerable<RoomDto>> GetRooms()
		{
			var response = await _httpClient.GetAsync("api/Room");
			if (response.IsSuccessStatusCode)
			{
				if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
				{
					return Enumerable.Empty<RoomDto>();
				}

				return await response.Content.ReadFromJsonAsync<IEnumerable<RoomDto>>();
			}

			var message = await response.Content.ReadAsStringAsync();
			throw new Exception(message);
		}

		public async Task<IEnumerable<PuzzleDto>> GetPuzzlesByRoomId(int roomId)
		{
			var response = await _httpClient.GetAsync($"api/Puzzle/{roomId}");

			if (response.IsSuccessStatusCode)
			{
				if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
				{
					return default(IEnumerable<PuzzleDto>);
				}

				return await response.Content.ReadFromJsonAsync<IEnumerable<PuzzleDto>>();

			}

			var message = await response.Content.ReadAsStringAsync();
			throw new Exception(message);

		}

		
	}
}
