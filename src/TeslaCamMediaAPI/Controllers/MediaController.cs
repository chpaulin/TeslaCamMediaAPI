using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TeslaCamMediaAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class MediaController : ControllerBase
	{
		private static string[] _cameras = new[] { "FRONT", "REAR", "LEFT", "RIGHT" };
		private readonly IMediaRepository _mediaRepository;

		public MediaController(IMediaRepository mediaRepository)
		{
			_mediaRepository = mediaRepository;
		}

		[HttpGet]
		[Route("recordings/{id}/{camera}.mp4")]
		public IActionResult GetRecording(long id, string camera)
		{
			if (!_cameras.Contains(camera.ToUpperInvariant()))
				return BadRequest("Invalid camera input");

			var fileInfo = _mediaRepository.GetFile(id, camera);

			if (fileInfo == null)
				return NotFound($"No recording was found for id '{id}'");

			return PhysicalFile(fileInfo.FullName, "application/octet-stream");
		}
	}
}