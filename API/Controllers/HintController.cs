using API.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HintController : ControllerBase
	{
		private IHintRepository _hintRepository;
		public HintController(IHintRepository hintRepository)
		{
			_hintRepository = hintRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<HintDto>>> GetHints()
		{

		}

	}
}
