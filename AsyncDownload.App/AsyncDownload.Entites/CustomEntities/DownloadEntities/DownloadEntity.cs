using AsyncDownload.Interfaces.IEntities.ICustomEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AsyncDownload.Entites.CustomEntities.DownloadEntities
{
	/// <summary>
	/// Entity for the download resources.
	/// </summary>
	public class DownloadEntity : IDownloadEntity
	{
		/// <summary>
		/// Download Rsource Path
		/// </summary>
		public Uri resourcePath { get; set; }

		/// <summary>
		/// Download Resource Length
		/// </summary>
		public int resourceLength { get; set; }
	}
}
