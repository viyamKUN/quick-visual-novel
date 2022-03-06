using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace QVN.DefaultUI
{
    public enum SceneName
    {
        Home, Story
    }

    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private GameObject _loadingCanvas;
        [SerializeField]
        private Image _progressBar;
        float timer;

        public void Load(SceneName sceneName)
        {
            Load(sceneName.ToString());
        }

        public void Load(string sceneName)
        {
            _loadingCanvas.SetActive(true);
            StartCoroutine(LoadScene(sceneName));
        }

        IEnumerator LoadScene(string sceneName)
        {
            return LoadStatically(sceneName, (progress) =>
            {
                _progressBar.fillAmount = Mathf.Lerp(_progressBar.fillAmount, progress, timer);
            });
        }

        /// <summary>Scene 로딩 함수. 각 <c>MonoBehaviour</c> 내부에서는 <c>StartCoroutine<c>으로 호출해주세요.</summary>
        /// <param name="sceneName">Scene 명을 나타내는 Enumerator</param>
        /// <param name="progressCallback">Progress 상황을 넘겨받는 <c>Action<float><c/> 함수</param>
        /// <param name="doneCallback">완료 상황을 넘겨받는 <c>Action<c/> 함수</param>
        public static IEnumerator LoadStatically(SceneName sceneName, Action<float> progressCallback = null, Action doneCallback = null)
        {
            return LoadStatically(sceneName.ToString(), progressCallback, doneCallback);
        }

        /// <summary>Scene 로딩 함수. 각 <c>MonoBehaviour</c> 내부에서는 <c>StartCoroutine<c>으로 호출해주세요.</summary>
        /// <para>allowSceneActivation을 false로 변경한 후 로딩하여 progress는 0.9까지만 올라갈 수 있습니다. 자세한 사항은 문서를 참고해주세요.
        /// <see href="https://docs.unity3d.com/ScriptReference/AsyncOperation-allowSceneActivation.html"/></para>
        /// <param name="sceneName">Scene 명을 나타내는 string</param>
        /// <param name="progressCallback">Progress 상황을 넘겨받는 <c>Action<float><c/> 함수</param>
        /// <param name="doneCallback">완료 상황을 넘겨받는 <c>Action<c/> 함수</param>
        public static IEnumerator LoadStatically(string sceneName, Action<float> progressCallback = null, Action doneCallback = null)
        {
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
            op.allowSceneActivation = false;
            while (!op.isDone)
            {
                yield return null;
                progressCallback?.Invoke(op.progress);

                // When allowSceneActivation is set to false, Unity stops progress at 0.9, and maintains.isDone at false.
                if (op.progress >= 0.9f)
                    break;
            }
            doneCallback?.Invoke();
            op.allowSceneActivation = true;
        }
    }
}
