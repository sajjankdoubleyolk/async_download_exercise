using AsyncDownload.Interfaces.IRepository;
using AsyncDownload.Interfaces.IService;
using AsyncDownload.Repository;
using AsyncDownload.Services;
using AsyncDownload.Utilities.CommonFunctions;
using AsyncDownload.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDownload.App
{
	/// <summary>
	/// Main Executable Method Class.
	/// </summary>
	class Program
	{
		/// <summary>
		/// Entry point of the programme
		/// (Used to prepare test data, provide cancel mechanism and test the DownloadResourcesAsync Method.)
		/// </summary>
		/// <returns></returns>
		static async Task Main()
		{
			//Print applicaton started message on the user screen.
			Utility.ShowMessage(DefaultConstants.startMessage);

			//Prepare download resources URLs List for testing.
			IEnumerable<string> resourcePaths = DefaultConstants.defaultResourcePaths;

			//Initialize  Cancellation Token Source.
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

			//Get Cancellation Token.
			CancellationToken userCancellationToken = cancellationTokenSource.Token;

			//Provide a way to cancel operation anytime.
			Utility.ShowMessage(DefaultConstants.cancelMessage);
			Utility.ShowMessage(DefaultConstants.separator);

			//Handle Cancellation by User.
			Task cancelTask = Task.Run(() =>
			{
				//Detect key press by user.
				while (Console.ReadKey().Key != DefaultConstants.cancelKey)
				{
					//Prompt if any other key is pressed.
					Utility.ShowMessage(DefaultConstants.wrongCancelKeyMessage);
				}

				//Cancel the Async operation on user request.
				Utility.ShowMessage(DefaultConstants.validCancelKeyMessage);

				//Cencel async download operation.
				cancellationTokenSource.Cancel();
			});


			//Initialize repository instance for data operations.
			IResourcesRepository resourcesRepository = new ResourcesRepository();
			//Initialize download service for business operations with specific data repository.
			IDownloadService downloadService = new DownloadService(resourcesRepository);

			//Download resources asynchronously
			Task aggregateContentLengthsTask = downloadService.DownloadResourcesAsync(resourcePaths, userCancellationToken);

			//Return task result when completed or cancelled.
			await Task.WhenAny(new[] { cancelTask, aggregateContentLengthsTask });

			//Print applicaton completed message on the user screen.
			Utility.ShowMessage(DefaultConstants.separator);
			Utility.ShowMessage(DefaultConstants.endMessage);
		}
	}
}
