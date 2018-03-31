using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject _manager;
    public int _class;
    public GameObject _war;
    public GameObject _arch;

    private void Awake()
    {
        _class = GameObject.Find("UIManager").GetComponent<UIManagerScript>()._pick;
        _manager = GameObject.Find("UIManager");


        if (_class == 1)
        {


            Instantiate(_war, transform.position, transform.rotation);
            Debug.Log("war");
        }
        if (_class == 2)
        {


            Instantiate(_arch, transform.position, transform.rotation);
            Debug.Log("arch");
        }
    }

    void Start()
    {
        
        
    }


}
