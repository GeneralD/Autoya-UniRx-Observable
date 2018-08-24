using System;
using AutoyaFramework.Settings.AssetBundles;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Autoya.Utility {
	public partial class AutoyaUtils : MonoBehaviour {

		public static IObservable<Autoya.ListDownloadResult> DownloadAssetBundleListsIfNeed(double timeoutSec = AssetBundlesSettings.TIMEOUT_SEC) =>
										Observable.Create<Autoya.ListDownloadResult>(observer => {
											AutoyaFramework.AssetBundle_DownloadAssetBundleListsIfNeed((Autoya.ListDownloadResult result) => {
												observer.OnNext(result);
												observer.OnCompleted();
											}, (err, message, status) => observer.OnError(new AutoyaListDownloadException(message, err, status)), timeoutSec);
											return Disposable.Create(() => { });
										});

		public static IObservable<string> LoadScene(string sceneAssetName, LoadSceneMode mode = LoadSceneMode.Single, bool async = true) =>
		Observable.Create<string>(observer => {
			Autoya.AssetBundle_LoadScene(sceneAssetName, mode, sceneName => {
				observer.OnNext(sceneName);
				observer.OnCompleted();
			}, (assetName, err, message, status) => observer.OnError(new AutoyaAssetBundleLoadException(message, assetName, err, status)), async);
			return Disposable.Create(() => { });
		});
	}
}