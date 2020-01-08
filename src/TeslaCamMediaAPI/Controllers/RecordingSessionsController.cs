using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TeslaCamMediaAPI.Model;

namespace TeslaCamMediaAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RecordingSessionsController : ControllerBase
	{
		private readonly ILogger<RecordingSessionsController> _logger;
		private readonly IRecordingsRepository _recordingsRepository;

		public RecordingSessionsController(IRecordingsRepository recordingsRepository, ILogger<RecordingSessionsController> logger)
		{
			_logger = logger;
			_recordingsRepository = recordingsRepository;
		}

		[HttpGet]
		public ActionResult<IEnumerable<RecordingSession>> Get()
		{
			var recordingSessions = _recordingsRepository.GetSessionsAsync();

			return Ok(recordingSessions);
		}
	}
}
