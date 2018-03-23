using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour
{
    public GameObject _warrior;
    public GameObject _manager;

    
    public int _pick = 0;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        
    }

    public void Start()
    {
        _warrior.GetComponent<Button>().onClick.AddListener(delegate { Pick(); });
    }
    public void Pick()
    {
        _pick = 1;
        PlayerPrefs.SetFloat("pick",_pick);
        Debug.Log("save warrior");
        SceneManager.LoadScene("Level1");
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    
}
