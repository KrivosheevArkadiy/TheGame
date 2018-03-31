﻿using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
        public Transform target;            
        public float smoothing = 5f;        


        Vector3 offset;                     


        void Start ()
        {

            FindPlayer();

        }

        private void FindPlayer()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            offset = transform.position - target.position;
        }

        void FixedUpdate ()
        {
            
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
        void Update()
        {
            
        }
    }
    
