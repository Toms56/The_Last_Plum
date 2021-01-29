using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void onClick_Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void onClick_Play()
    {
        SceneManager.LoadScene(1);
    }

    public void onClick_CharactersScene()
    {
        SceneManager.LoadScene(2);
    }

    public void onClick_Tuto()
    {
        SceneManager.LoadScene(3);
    }
    
    public void exitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
