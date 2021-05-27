using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cutscene1Controller : MonoBehaviour
{
    [SerializeField] private CanvasGroup[] CutScenes;
    [SerializeField] private GameObject ButtonSkip, ButtonNext;

    private int counter = 0;

    void Start()
    {
        Fadein(counter);
    }

    public void NextScene()
    {
        if (counter == 2)
        {
            FadeOut(0);
            FadeOut(1);
            FadeOut(2);
        }
        if (counter == 5)
        {
            FadeOut(3);
            FadeOut(4);
            FadeOut(5);
        }
        ++counter;
        if (counter > 5)
        {
            SceneLoader("Game");
        }
        else
        {
            Fadein(counter);
        }
               
    }

    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Fadein(int counter)
    {
        StartCoroutine(FadeCanvasGroup(CutScenes[counter], CutScenes[counter].alpha, 1));
    }

    public void FadeOut(int counter)
    {
        StartCoroutine(FadeCanvasGroup(CutScenes[counter], CutScenes[counter].alpha, 0));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;
        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();            
        }
    }

}
