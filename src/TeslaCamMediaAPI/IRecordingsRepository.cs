using System.Collections.Generic;
using System.Threading.Tasks;
using TeslaCamMediaAPI.Model;

namespace TeslaCamMediaAPI
{
	public interface IRecordingsRepository
	{
		IReadOnlyList<RecordingSession> GetSessionsAsync();
	}
}