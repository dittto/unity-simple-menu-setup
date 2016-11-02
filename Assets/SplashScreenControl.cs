using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LevelSelectControl))]
public class SplashScreenControl : MonoBehaviour
{
    public GameObject splashScreen;

    public void Start()
    {
        splashScreen.SetActive(true);
        StartCoroutine(CoroutineShowSplashScreen());
    }

    private IEnumerator CoroutineShowSplashScreen()
    {
        yield return new WaitForSeconds(3f);

        CanvasGroup canvas = splashScreen.GetComponent<CanvasGroup>();

        for (int i = 100; i > 0; i = i - 2) {
            canvas.alpha = i / 100f;
            yield return null;
        }

        splashScreen.SetActive(false);

        this.GetComponent<LevelSelectControl>().ShowLevelControl();
    }
}
