using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("Start", LoadSceneMode.Single);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void Info()
    {
        SceneManager.LoadScene("Info", LoadSceneMode.Single);
    }
    public void Levels()
    {
        SceneManager.LoadScene("Levels", LoadSceneMode.Single);
    }
    public void LoadedMenu()
    {
        SceneManager.LoadScene("LoadedMenu", LoadSceneMode.Single);
    }
    public void Ending()
    {
        SceneManager.LoadScene("Ending", LoadSceneMode.Single);
    }
}
