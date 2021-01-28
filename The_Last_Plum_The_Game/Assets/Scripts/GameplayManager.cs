using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;
    public GameObject defenseTower;
    public GameObject enemy;
    public GameObject centralTree;
    public List<GameObject>defenseTowers = new List<GameObject>();
    public List<GameObject>enemies = new List<GameObject>();
    
    //Panel Management
    public GameObject panelGameOver;

    public GameObject panelWonLevel;

    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    public void ShowGameOver()
    {
        panelGameOver.SetActive(true);
    }
    
    public void ShowWonLevel()
    {
        panelWonLevel.SetActive(true);
    }
    
    public void onClick_Retry()
    {
        SceneManager.LoadScene(1);
    }
    
    public void exitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    
}
