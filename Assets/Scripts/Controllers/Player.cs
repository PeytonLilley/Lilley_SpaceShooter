using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Transform playerTransform;

    public float speed = 0.05f;   // added a public speed variable to be able to change the speed from the inspector
    public float accel = 0;
    public float accelSpeed = 0.017f;
    public float maxAccel = 0.2f;

    public float radius;
    public int circlePoints;
    public float circleAngle;

    public int numberOfPowerups;
    public GameObject powerupPrefab;

    void Update()
    {
        EnemyRadar(radius, circlePoints);
        SpawnPowerups(radius, numberOfPowerups);
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }

    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        numberOfPowerups = 5;
        radius = 2;
        circleAngle = (2 * Mathf.PI) / numberOfPowerups;
        Vector3 powerupPos = new Vector3(playerTransform.position.x, playerTransform.position.y);

        for (int i = 0; i < numberOfPowerups; i++)
        {
            Instantiate(powerupPrefab, new Vector3(playerTransform.position.x + radius * circleAngle * i, playerTransform.position.y + radius * circleAngle * i), Quaternion.identity);

            
            powerupPos.x = playerTransform.position.x + Mathf.Cos(circleAngle * i);
            powerupPos.y = playerTransform.position.y + Mathf.Sin(circleAngle * i);
  //          Instantiate(powerupPrefab, new Vector3(powerupPos.x, powerupPos.y, Quaternion.identity);
        }
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        radius = 2;
        circlePoints = 8;
        circleAngle = (2 * Mathf.PI) / circlePoints;
        Vector3 lineStart = new Vector3(playerTransform.position.x, playerTransform.position.y);
        Vector3 lineEnd = new Vector3(playerTransform.position.x, playerTransform.position.y);

        for (int i = 0; i < circlePoints; i++)
        {
            lineStart.x = playerTransform.position.x + Mathf.Cos(circleAngle * i);
            lineStart.y = playerTransform.position.y + Mathf.Sin(circleAngle * i);

            lineEnd.x = playerTransform.position.x + Mathf.Cos(circleAngle * (i + 1));
            lineEnd.y = playerTransform.position.y + Mathf.Sin(circleAngle * (i + 1));
            
            float shipsDistance = Vector3.Distance(playerTransform.position, enemyTransform.position);
            if (shipsDistance <= radius)
            {
                Debug.DrawLine(lineStart, lineEnd, Color.red);
            }
            else
            {
                Debug.DrawLine(lineStart, lineEnd, Color.green);
            }
        }
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
