using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levell : MonoBehaviour
{
    public GameObject levelpanel;
    public GameObject menupanel;

    // Start is called before the first frame update
    void Start()
    {
        levelpanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LevelMudah(string mudah)
    {
        SceneManager.LoadScene(mudah);
    }

    public void LevelSulit(string sulit)
    {
        SceneManager.LoadScene(sulit);
    }

    // Corrected TombolKembali method
    public void TombolKembali()
    {
        SceneManager.LoadScene(0);
    }
}