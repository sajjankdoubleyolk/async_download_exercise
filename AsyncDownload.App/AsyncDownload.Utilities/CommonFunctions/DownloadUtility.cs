using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDownload.Utilities.CommonFunctions
{
	/// <summary>
	/// Class to handle common download operations.
	/// </summary>
	public static class DownloadUtility
	{
		/// <summary>
		/// Method to process each URL seperate asynchronously.
		/// </summary>
		/// <param name="resourceURL"></param>
		/// <param name="httpClient"></param>
		/// <param name="userCancellationToken"></param>
		/// <returns>Content length for a specific URL.</returns>
		public static async Task<int> DownloadSingleUrlContentAsync(string resourceURL, HttpClient httpClient, CancellationToken userCancellationToken)
		{
			//Get URL content.
			HttpResponseMessage httpResponse = await httpClient.GetAsync(resourceURL, userCancellationToken);

			//Read content bytes.
			byte[] contentBytesArray = await httpResponse.Content.ReadAsByteArrayAsync();

			//Determine length and print intermediate results on the screen.
			Utility.ShowMessage($"{resourceURL,-60} {contentBytesArray.Length,10:#,#}");

			//Return specific URL content length to the calling async method.
			return contentBytesArray.Length;
		}
	}
}
