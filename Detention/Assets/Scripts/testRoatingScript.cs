using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRoatingScript : MonoBehaviour {


    private Vector3 center;
    private float radius;
    private Vector3 positionOnCircle;
    private bool isOnCircle;
    private float angle;
    private int speed;

    // Use this for initialization
    void Start () {
        center = transform.position;
        radius = GetComponent<Collider>().bounds.size.magnitude;
        positionOnCircle = center + new Vector3(radius, 0, 0);
        isOnCircle = false;
        angle = 0;
        speed = 100;
    }
	
	// Update is called once per frame
	void Update () {

        if (!isOnCircle && (transform.position - positionOnCircle).magnitude < 0.0001)
        {
            if (!isOnCircle)
            {
                angle = Vector3.Angle(
                    transform.position - center,
                    positionOnCircle - center);
            }
            isOnCircle = true;
 
        }

        if (isOnCircle)
        {

            float dx = Mathf.Cos(angle * Mathf.Deg2Rad * speed) * radius;
            float dy = Mathf.Sin(angle * Mathf.Deg2Rad * speed) * radius;

            transform.position = center + new Vector3(dx, 0, dy);

            angle += Time.deltaTime;
        }
        else
        { 
            transform.position = Vector3.MoveTowards(transform.position, positionOnCircle, Time.deltaTime);
        }
    }
}
