using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace MainraFramework
{
	public class SceneManager
	{
		private GameManager gameManager;

		public SceneManager(GameManager gameManager)
		{
			this.gameManager = gameManager;
		}

		public void LoadScene(string sceneName, bool showLoadingScene = false, float fakeLoadingTime = 3f)
		{
			if (showLoadingScene)
			{
				gameManager.StartCoroutine(LoadSceneWithLoadingScreen(sceneName, fakeLoadingTime));
			}
			else
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
			}
		}

		private IEnumerator LoadSceneWithLoadingScreen(string sceneName, float fakeLoadingTime)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene");

			yield return null;

			AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
			operation.allowSceneActivation = false;

			float elapsedTime = 0f;
			while (!operation.isDone)
			{
				if (operation.progress >= 0.9f && elapsedTime >= fakeLoadingTime)
				{
					operation.allowSceneActivation = true;
				}

				elapsedTime += Time.deltaTime;
				UIManager.Instance.GetUIInstance<LoadingUI>().LoadingProgress(operation.progress);
				yield return null;
			}
		}
	}
}