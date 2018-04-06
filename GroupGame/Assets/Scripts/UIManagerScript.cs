using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIManagerScript : MonoBehaviour
{
    
    public GameObject _manager;
    


    public int _pick = 0;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        
    }

    public void Start()
    {
        
    }

    

    public void PickWar()
    {
        _pick = 1;
        Debug.Log("save warrior");
        SceneManager.LoadScene("Level1");
    }
    public void PickArch()
    {
        _pick = 2;
        Debug.Log("save archer");
        SceneManager.LoadScene("Level1");
    }

    public void PickWizard()
    {
        _pick = 3;
        Debug.Log("save wizard");
        SceneManager.LoadScene("Level1");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    
}
