using Microsoft.Extensions.Options;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TeslaCamMediaAPI.Model;

namespace TeslaCamMediaAPI
{
	public class RecordingsRepository : IRecordingsRepository
	{
		private Settings _settings;
		private readonly IBaseUrlHelper _baseUrlHelper;

		public RecordingsRepository(IOptions<Settings> settings, IBaseUrlHelper baseUrlHelper)
		{
			_settings = settings.Value;
			_baseUrlHelper = baseUrlHelper;
		}

		public IReadOnlyList<RecordingSession> GetSessionsAsync()
		{
			var directory = new DirectoryInfo(_settings.ArchivePath);

			var files = directory.GetFiles("*.mp4", SearchOption.AllDirectories);

			var fileGroups = files.GroupBy(f => f.Directory.Name).ToDictionary(g => g.Key, g => g.ToList());

			var recordingGroups = new List<RecordingSession>();			

			foreach (var group in fileGroups)
			{
				var recordingDate = DateTime.ParseExact(group.Key.Substring(0, 19), "yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

				var recordings = group.Value
					.DistinctBy(f => f.Name.Substring(0, 19))
					.Select(f => new Recording(DateTime.ParseExact(f.Name.Substring(0, 19), "yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal), _baseUrlHelper.BaseUrl));

				var recordingGroup = new RecordingSession(directoryPath: group.Key, recordingDate) { Recordings = recordings };

				recordingGroups.Add(recordingGroup);
			}

			return recordingGroups;
		}
	}
}