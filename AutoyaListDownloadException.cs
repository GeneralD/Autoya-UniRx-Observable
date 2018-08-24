using System;
using AutoyaFramework;

namespace Autoya.Utility {
	public class AutoyaListDownloadException : Exception {
		public Autoya.ListDownloadError AutoyaListDownloadError { get; }
		public AutoyaStatus AutoyaStatus { get; }

		public AutoyaListDownloadException(string message, Autoya.ListDownloadError error, AutoyaStatus status) : base(message) {
			AutoyaListDownloadError = error;
			AutoyaStatus = status;
		}
	}
}