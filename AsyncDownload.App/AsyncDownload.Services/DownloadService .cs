using AsyncDownload.Interfaces.IRepository;
using AsyncDownload.Interfaces.IService;
using AsyncDownload.Utilities.CommonFunctions;
using AsyncDownload.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDownload.Services
{
	/// <summary>
	/// Download service class having business function's definitions.
	/// </summary>
	public class DownloadService : IDownloadService
	{
		//Repository instance for data operations.
		private IResourcesRepository resourcesRepository;

		/// <summary>
		/// Class constructor method to initialize local members.
		/// </summary>
		/// <param name="resourcesRepository"></param>
		public DownloadService(IResourcesRepository resourcesRepository)
		{
			this.resourcesRepository = resourcesRepository;
		}

		/// <summary>
		/// Asynchronous method that downloads any number of resources and 
		/// aggregates the content length of all provided responses. 
		/// The caller can cancel the operation at any time. 
		/// </summary>
		/// <param name="resourcePaths">Valid URLs list.</param>
		/// <param name="userCancellationToken">Valid user cancellation token.</param>
		/// <returns></returns>
		public async Task DownloadResourcesAsync(IEnumerable<string> resourcePaths, CancellationToken userCancellationToken)
		{
			//Initialize Stopwatch to determine total time.
			var stopwatch = Stopwatch.StartNew();

			//Initialize httpClient to be used to download content.
			HttpClient httpClient = new HttpClient();

			//Prepare contents list to show the intermediate results.
			//Maintained this to show all final results or maximum possible results before cancellation.
			List<int> contentLengths = new List<int>();

			//Process each URL asynchronously and keep results
			foreach (string url in resourcePaths)
			{
				//Get content lengh for a specific URL.
				int contentLength = await DownloadUtility.DownloadSingleUrlContentAsync(url, httpClient, userCancellationToken);

				//Store results to create maximum possible result before cancelation.
				contentLengths.Add(contentLength);
			}

			//Stop watch after Async operation completed.
			stopwatch.Stop();
			Utility.ShowMessage(DefaultConstants.separator);

			//Print total results on the screen.
			var grandTotal = contentLengths.Sum();
			Utility.ShowMessage($"\nContent Grand total:  {grandTotal:#,#}");

			//Print average on the screen.
			Utility.ShowMessage($"\nContent Average:  {grandTotal / contentLengths.Count():#,#}");

			//Print total Async operation time on screen.
			Utility.ShowMessage(DefaultConstants.separator);
			Utility.ShowMessage($"\nTotal Elapsed time:          {stopwatch.Elapsed}\n");
		}
	}
}
