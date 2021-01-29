using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;
    public GameObject defenseTower;

    public GameObject player;

    public CentralTree centralTree;

    //Money
    public float currencyFund;
    public Text currencyTxt;
    
    public GameObject enemy;
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

    private void Update()
    {
        if (player != null)
        {
            currencyTxt.text = " " + currencyFund;
        }
    }

    public void ShowGameOver()
    {
        Debug.Log("ShowGameOver");
        panelGameOver.SetActive(true);
    }
    
    public void ShowWonLevel()
    {
        panelWonLevel.SetActive(true);
    }
    
     public void OnClick_Mute() 
     { 
         AudioListener.pause = !AudioListener.pause;
     }
    
    public void onClick_Retry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    
    public void exitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        Debug.Log("Game is exiting");
    }
    
}
