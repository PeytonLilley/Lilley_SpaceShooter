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

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()   // added an if statement for each direction, now it moves 1 in each direction depending on the key pressed
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + (Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + (Vector3.up * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + (Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + (Vector3.down * speed);   // multiplied by speed variable to change speed of movement
        }
    }

}
