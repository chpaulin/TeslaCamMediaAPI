using System.Text.Json.Serialization;

namespace TeslaCamMediaAPI
{
	public class Settings
	{
		[JsonPropertyName("ATCHIVEPATH")]
		public string ArchivePath { get; set; }
	}
}
