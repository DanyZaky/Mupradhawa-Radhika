using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPanelController : MonoBehaviour
{
    [SerializeField] private GameObject[] DialogWindows;
    [SerializeField] private GameObject DisAttButt, WordGrid, GameUI;
    [SerializeField] private AudioSource HitButton;

    private int counter = 0;
 
    void Start()
    {
        DialogWindows[counter].SetActive(true);
        DisAttButt.SetActive(false);
        WordGrid.SetActive(false);
        GameUI.SetActive(false);
    }

    public void NextDialog()
    {
        HitButton.Play();
        if (counter != DialogWindows.Length - 1)
        {
            DialogWindows[counter].SetActive(false);
            ++counter;
            DialogWindows[counter].SetActive(true);
        }
        else
        {
            DialogWindows[counter].SetActive(false);
            DisAttButt.SetActive(true);
            WordGrid.SetActive(true);
            GameUI.SetActive(true);
            print("Done");
        }
        
    }
}
