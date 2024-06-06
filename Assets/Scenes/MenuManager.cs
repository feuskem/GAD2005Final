using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class MenuManager : MonoBehaviour
{

    public GameObject HowToPlayPanel;
    public GameObject LevelSelectionPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void SelectLevel()
    {
        LevelSelectionPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        LevelSelectionPanel.SetActive(false);
        HowToPlayPanel.SetActive(false);
    }

    public void HowToPlay()
    {
        HowToPlayPanel.SetActive(true);
    }

    public void OpenLevel1()
    {
         SceneManager.LoadScene(1);
    }

    public void OpenLevel2()
    {
         SceneManager.LoadScene(2);
    }

    public void OpenLevel3()
    {
         SceneManager.LoadScene(3);
    }

    public void OpenLevel4()
    {
         SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
