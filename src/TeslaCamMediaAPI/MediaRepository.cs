using Microsoft.Extensions.Options;
using System.IO;
using System.Linq;
using TeslaCamMediaAPI.Extensions;

namespace TeslaCamMediaAPI
{
	public class MediaRepository : IMediaRepository
	{
		private readonly Settings _settings;

		public MediaRepository(IOptions<Settings> settings)
		{
			_settings = settings.Value;
		}

		public FileInfo GetFile(long id, string camera)
		{
			var creationDate = DateTimeUnixTimestampExtensions.ConvertFromUnixTimestamp(id);

			switch (camera.ToUpper())
			{
				case "FRONT":
					camera = "front";
					break;
				case "REAR":
					camera = "back";
					break;
				case "LEFT":
					camera = "left_repeater";
					break;
				case "RIGHT":
					camera = "right_repeater";
					break;
			}

			var fileName = $"{creationDate.ToString("yyyy-MM-dd_HH-mm-ss")}-{camera}.mp4";

			var directory = new DirectoryInfo(_settings.ArchivePath);

			var result = directory.GetFiles(fileName, SearchOption.AllDirectories);

			return result.FirstOrDefault();
		}
	}
}