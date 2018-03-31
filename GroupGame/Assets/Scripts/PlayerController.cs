using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    public float speedRotation = 10.0f;
    public GameObject player;
    public int speed = 5;
    public Vector3 target;
    private Ray ray;
    private RaycastHit hit;
    public Animator _anim;


    void Start()
    {
        player = (GameObject)this.gameObject;
        _anim = player.GetComponent<Animator>();


    }
    void Update()
        
    {
        Move();
        Rotation();

        
    }

    private void Rotation()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            target = hit.point;
        }
        Vector3 dir = (target - transform.position);
        dir = new Vector3(dir.x, 0, dir.z);
        if (dir != Vector3.zero) transform.forward = dir;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position += player.transform.forward * speed * Time.deltaTime;
            _anim.SetBool("IsMoving", true);
        }
        else player.GetComponent<Animator>().SetBool("IsMoving", false);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position -= player.transform.forward * speed * Time.deltaTime;
            _anim.SetBool("RunBack", true);
            _anim.SetBool("IsMoving", false);
        }
        else _anim.SetBool("RunBack", false);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.position -= player.transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.position += player.transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Mouse0))
            _anim.SetTrigger("Attack1Trigger");

    }
}
