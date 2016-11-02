using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectControl : MonoBehaviour
{
    public GameObject levelSelect;

    public GameObject loadingScreen;

    public void ShowLevelControl()
    {
        StartCoroutine(FadeIn(levelSelect));
    }

    public void SelectLevel(int sceneNumber)
    {
        // fade in loading screen
        StartCoroutine(FadeIn(loadingScreen));

        // load level async
        StartCoroutine(LoadScene(sceneNumber));
    }

    public IEnumerator FadeIn(GameObject obj)
    {
        CanvasGroup canvas = obj.GetComponent<CanvasGroup>();

        canvas.alpha = 0;
        obj.SetActive(true);

        for (int i = 0; i < 100; i = i + 2) {
            canvas.alpha = i / 100f;
            yield return null;
        }
    }

    private IEnumerator LoadScene(int sceneId)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneId);

        async.allowSceneActivation = false;
        yield return new WaitForSeconds(3f);
        async.allowSceneActivation = true;

        while (!async.isDone) {
            yield return null;
        }
    }
}
