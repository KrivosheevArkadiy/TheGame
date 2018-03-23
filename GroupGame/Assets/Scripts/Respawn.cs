using UnityEngine;

public class Respawn : MonoBehaviour {

    public GameObject _manager;
    public int _class;
    public GameObject _player;
    

    private void Awake()
    {
        _class = GameObject.Find("UIManager").GetComponent<UIManagerScript>()._pick;
    }
    void Start()
    {
        
        _manager = GameObject.Find("UIManager");
       

        if (_class == 1)
        {

            
            Instantiate(_player, transform.position, transform.rotation);
            Debug.Log("war");
        }
    }


}
