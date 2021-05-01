using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMenu : MonoBehaviour
{
    public GameObject playButton, gameLogo, settingButton, exitButton, backButton, chapter1Button, chapterScene;
    public AudioSource hitButtonSound, backButtonSound;

    public void tekanButtonPlay()
    {
        playButton.SetActive(false);
        gameLogo.SetActive(false);
        settingButton.SetActive(false);
        exitButton.SetActive(false);

        backButton.SetActive(true);
        chapter1Button.SetActive(true);
        chapterScene.SetActive(true);
        hitButtonSound.Play();
    }

    public void tekanButtonBack()
    {
        playButton.SetActive(true);
        gameLogo.SetActive(true);
        settingButton.SetActive(true);
        exitButton.SetActive(true);

        backButton.SetActive(false);
        chapter1Button.SetActive(false);
        chapterScene.SetActive(false);
        backButtonSound.Play();
    }

    public void tekanButtonSetting()
    {
        hitButtonSound.Play();
    }

    public void tekanButtonChapter1()
    {
        hitButtonSound.Play();
    }
}
