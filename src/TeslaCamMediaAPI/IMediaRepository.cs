using System.IO;

namespace TeslaCamMediaAPI
{
	public interface IMediaRepository
	{
		FileInfo GetFile(long id, string camera);
	}
}