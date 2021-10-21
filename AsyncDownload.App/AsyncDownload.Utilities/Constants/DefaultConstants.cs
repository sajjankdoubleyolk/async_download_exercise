using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncDownload.Utilities.Constants
{
	/// <summary>
	/// All hard-coded strings can be read as properties in the application
	/// </summary>
	public static class DefaultConstants
	{
		/// <summary>
		/// Default Cancel Kay.
		/// </summary>
		public const ConsoleKey cancelKey = ConsoleKey.Enter;

		/// <summary>
		/// Custom separator.
		/// </summary>
		public const string separator = "-------------------------------------------------------";

		/// <summary>
		/// Default Applicaiton Start Message.
		/// </summary>
		public const string startMessage = "...Asynchronous app started...";

		/// <summary>
		/// Default Applicaiton End Message.
		/// </summary>
		public const string endMessage = "...Asynchronous app ended...";

		/// <summary>
		/// Default Applicaiton Cancel Message.
		/// </summary>
		public const string cancelMessage = "Press the ENTER key to cancel...\n";

		/// <summary>
		/// Default Wrong Cancel Key Press Message.
		/// </summary>
		public const string wrongCancelKeyMessage = "Wrong Key: Press the ENTER key to cancel...";

		/// <summary>
		/// Default Va;lid Cancel Key Press Message.
		/// </summary>
		public const string validCancelKeyMessage = "\nENTER key pressed: cancelling downloads.\n";

		//Default resources URLs List for testing.
		public static readonly IEnumerable<string> defaultResourcePaths = new string[]
		{
			"https://docs.microsoft.com",
			"https://docs.microsoft.com/aspnet/core",
			"https://docs.microsoft.com/azure"
		};

	}
}
