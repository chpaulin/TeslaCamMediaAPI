using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TeslaCamMediaAPI.Extensions;

namespace TeslaCamMediaAPI.Model
{
	public class RecordingSession
	{
		private readonly DateTime _recordingDate;

		public RecordingSession(string directoryPath, DateTime recordingDate)
		{
			DirectoryPath = directoryPath;
			_recordingDate = recordingDate;
		}

		public IEnumerable<Recording> Recordings { get; internal set; }

		[JsonIgnore]
		public string DirectoryPath { get; internal set; }

		public DateTime? From => Recordings.FirstOrDefault()?.CreationTime;

		public DateTime? To => Recordings.LastOrDefault()?.CreationTime;

		public long Id => _recordingDate.ToUnixTimestamp();

		public async Task DeleteAsync()
		{
			await Task.CompletedTask;
		}
	}
}