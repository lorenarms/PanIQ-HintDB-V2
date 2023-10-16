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


		public async Task<IEnumerable<HintDto>> GetItems()
		{
			try
			{
				var hints = await _httpClient.GetFromJsonAsync<IEnumerable<HintDto>>("api/Hint");
				return hints;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<IEnumerable<RoomDto>> GetRooms()
		{
			try
			{
				var rooms = await _httpClient.GetFromJsonAsync<IEnumerable<RoomDto>>("api/Room");
				return rooms;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
