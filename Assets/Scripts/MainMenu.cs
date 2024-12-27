using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject menupanel;
    public GameObject infopanel;
    public GameObject howplaypanel;

    void start()
    {
        menupanel.SetActive(true);
        infopanel.SetActive(false);
    }
    public void StartButton(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void InfoButton()
    {
        menupanel.SetActive(false);
        infopanel.SetActive(true);
    }

    public void BackButton()
    {
        menupanel.SetActive(true);
        infopanel.SetActive(false);
    }

    public void HowButton()
    {
        menupanel.SetActive(false);
        howplaypanel.SetActive(true);
    }

    public void BackButton2()
    {
        menupanel.SetActive(true);
        howplaypanel.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
