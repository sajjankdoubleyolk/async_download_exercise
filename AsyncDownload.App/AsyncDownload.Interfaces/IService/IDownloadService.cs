using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDownload.Interfaces.IService
{
	public interface IDownloadService
	{
		abstract Task DownloadResourcesAsync(IEnumerable<string> resourcePaths, CancellationToken userCancellationToken);
	}
}
