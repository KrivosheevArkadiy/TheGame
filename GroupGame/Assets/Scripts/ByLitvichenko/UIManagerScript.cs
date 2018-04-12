using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIManagerScript : MonoBehaviour
{
    public GameObject _manager;
    public string _pick = "none";
    

    void Awake()
    {
        _manager = gameObject;
        Load();
    }
    public void Save()
    {
        PlayerPrefs.SetString("pick", _manager.GetComponent<UIManagerScript>()._pick);
    }
    public void Load()
    {
        _manager.GetComponent<UIManagerScript>()._pick = PlayerPrefs.GetString("pick");
    }
    public void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
    
    public void PickWar()
    {
        _pick = "warrior";
        Debug.Log("save warrior");
        SceneManager.LoadScene("Level1");
    }
    public void PickArch()
    {
        _pick = "archer";
        Debug.Log("save archer");
        SceneManager.LoadScene("Level1");
    }

    public void PickWizard()
    {
        _pick = "wizard";
        Debug.Log("save wizard");
        SceneManager.LoadScene("Level1");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    
}
