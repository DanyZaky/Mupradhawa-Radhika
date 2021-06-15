using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMenu : MonoBehaviour
{
    public GameObject playButton, gameLogo, settingButton, exitButton, backButton, chapter1Button, chapterScene, button_sfx_on, button_sfx_off, button_music_on, button_music_off;
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
        hitButtonSound.Play();
    }

    public void tekanButtonChapter1()
    {
        hitButtonSound.Play();
    }

    public void tekanButtonSFX_On()
    {
        hitButtonSound.Play();
        button_sfx_off.SetActive(true);
        button_sfx_on.SetActive(false);
    }

    public void tekanButtonSFX_Off()
    {
        hitButtonSound.Play();
        button_sfx_off.SetActive(false);
        button_sfx_on.SetActive(true);
    }

    public void tekanButtonMusic_On()
    {
        hitButtonSound.Play();
        button_music_off.SetActive(true);
        button_music_on.SetActive(false);
    }

    public void tekanButtonMusic_Off()
    {
        hitButtonSound.Play();
        button_music_off.SetActive(false);
        button_music_on.SetActive(true);
    }

}
