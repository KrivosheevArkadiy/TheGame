using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject _manager;
    public string _class;
    public GameObject _war;
    public GameObject _arch;
    public GameObject _wiz;

    private void Awake()
    {
        _class = GameObject.Find("UIManager").GetComponent<UIManagerScript>()._pick;
        _manager = GameObject.Find("UIManager");

        switch (_class)
        {
            case "warrior":
                Instantiate(_war, transform.position, transform.rotation);
                Debug.Log("war");
                break;
            case "archer":
                Instantiate(_arch, transform.position, transform.rotation);
                Debug.Log("arch");
                break;
            case "wizard":
                Instantiate(_wiz, transform.position, transform.rotation);
                Debug.Log("wiz");
                break;
        }
        
    }

    void Start()
    {
        
        
    }


}
