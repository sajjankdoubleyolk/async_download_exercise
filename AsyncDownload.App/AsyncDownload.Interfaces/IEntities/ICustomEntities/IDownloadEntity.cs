using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncDownload.Interfaces.IEntities.ICustomEntities
{

	/// <summary>
	/// Contract for the download resources.
	/// </summary>
	public interface IDownloadEntity
	{
		/// <summary>
		/// Download Rsource Path
		/// </summary>
		Uri resourcePath { get; set; }

		/// <summary>
		/// Download Resource Length
		/// </summary>
		int resourceLength { get; set; }
	}
}
