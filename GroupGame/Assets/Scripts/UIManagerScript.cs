using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public GameObject _warrior;
    public GameObject _archer;
    public GameObject _manager;

    
    public int _pick = 0;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        
    }

    public void Start()
    {
        _warrior.GetComponent<Button>().onClick.AddListener(delegate { PickWar(); });
        _archer.GetComponent<Button>().onClick.AddListener(delegate { PickArch(); });
    }
    public void PickWar()
    {
        _pick = 1;
        PlayerPrefs.SetFloat("pick",_pick);
        Debug.Log("save warrior");
        SceneManager.LoadScene("Level1");
    }
    public void PickArch()
    {
        _pick = 2;
        PlayerPrefs.SetFloat("pick", _pick);
        Debug.Log("save archer");
        SceneManager.LoadScene("Level1");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    
}
