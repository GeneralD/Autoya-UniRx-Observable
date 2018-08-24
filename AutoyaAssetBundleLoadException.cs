using System;
using AutoyaFramework;
using AutoyaFramework.AssetBundles;

namespace Autoya.Utility {
	public class AutoyaAssetBundleLoadException : Exception {
		public AssetBundleLoadError AssetBundlesError { get; }
		public AutoyaStatus AutoyaStatus { get; }
		public string AssetName { get; }

		public AutoyaAssetBundleLoadException(string message, string assetName, AssetBundleLoadError error, AutoyaStatus status) : base(message) {
			AssetName = assetName;
			AssetBundlesError = error;
			AutoyaStatus = status;
		}
	}
}