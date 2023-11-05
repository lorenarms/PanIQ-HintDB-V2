using System.Net.Http.Json;
using Client.Services.Contracts;
using Models.DTOs;

namespace Client.Services
{
	public class RoomService : IRoomService
	{
		private readonly HttpClient _httpClient;

		public RoomService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<IEnumerable<RoomDto>> GetRooms()
		{
			var response = await _httpClient.GetAsync($"api/Rooms");
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


		public async Task<RoomDto> GetRoom(int roomId)
		{
			var response = await _httpClient.GetAsync($"api/Puzzles/{roomId}");
			if (response.IsSuccessStatusCode)
			{
				if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					return default;
				}

				return await response.Content.ReadFromJsonAsync<RoomDto>();

			}

			var message = await response.Content.ReadAsStringAsync();
			throw new Exception(message);

		}
	}
}
