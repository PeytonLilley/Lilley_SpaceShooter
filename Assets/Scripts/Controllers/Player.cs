using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public float speed = 0.05f;   // added a public speed variable to be able to change the speed from the inspector
    public float accel = 0;
    public float accelSpeed = 0.017f;
    public float maxAccel = 0.2f;


    void Update()
    {
        
        
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()   // added an if statement for each direction, now it moves 1 in each direction depending on the key pressed
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            accel = accel + accelSpeed;
            
            transform.position = transform.position + (Vector3.left * speed * accel) * Time.deltaTime;
            if (accel >=  maxAccel)
            {
                accel = maxAccel;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            accel = accel - accelSpeed;
            if (accel <= 0)
            {
                accel = 0;
            }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            accel = accel + accelSpeed;

            transform.position = transform.position + (Vector3.up * speed) * Time.deltaTime;
            if (accel >= maxAccel)
            {
                accel = maxAccel;
            }
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            accel = accel - accelSpeed;
            if (accel <= 0)
            {
                accel = 0;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            accel = accel + accelSpeed;

            transform.position = transform.position + (Vector3.right * speed) * Time.deltaTime;
            if (accel >= maxAccel)
            {
                accel = maxAccel;
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            accel = accel - accelSpeed;
            if (accel <= 0)
            {
                accel = 0;
            }
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            accel = accel + accelSpeed;

            transform.position = transform.position + (Vector3.down * speed) * Time.deltaTime;   // multiplied by speed variable to change speed of movement and Time.deltaTime to avoid frame rate issues
            if (accel >= maxAccel)
            {
                accel = maxAccel;
            }
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            accel = accel - accelSpeed;
            if (accel <= 0)
            {
                accel = 0;
            }
        }


    }

}
