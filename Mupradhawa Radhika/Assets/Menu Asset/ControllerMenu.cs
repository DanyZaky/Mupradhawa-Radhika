using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMenu : MonoBehaviour
{
    public GameObject playButton, gameLogo, settingButton, exitButton, backButton, chapter1Button, chapterScene, settingWindow;
    public AudioSource hitButtonSound, backButtonSound, bgmSound;

    public void SceneLoader(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //DontDestroyOnLoad(bgmSound);
    }

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

    public void tekanOpenSetting()
    {
        playButton.SetActive(false);
        gameLogo.SetActive(false);
        settingButton.SetActive(false);
        exitButton.SetActive(false);

        settingWindow.SetActive(true);
        hitButtonSound.Play();
    }

    public void tekanCloseSetting()
    {
        playButton.SetActive(true);
        gameLogo.SetActive(true);
        settingButton.SetActive(true);
        exitButton.SetActive(true);

        settingWindow.SetActive(false);
        backButtonSound.Play();
    }

    public void tekanButtonChapter1()
    {
        hitButtonSound.Play();
    }

    public void tekanButtonSFX()
    {
        hitButtonSound.Play();
        if (hitButtonSound.volume == 1 || backButtonSound.volume == 1)
        {
            hitButtonSound.volume = 0;
            backButtonSound.volume = 0;
        }
        else
        {
            hitButtonSound.volume = 1;
            backButtonSound.volume = 1;
        }
    }

    public void tekanButtonMusic()
    {
        hitButtonSound.Play();
        if (bgmSound.volume != 0)
        {
            bgmSound.volume = 0;
        } else
        {
            bgmSound.volume = 0.416f;
        }
        
    }

}
