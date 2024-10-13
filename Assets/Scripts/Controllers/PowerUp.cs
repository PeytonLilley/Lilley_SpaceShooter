using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public Transform playerTransform;
    public Transform powerUpTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpMagnet();
    }

    public void PowerUpMagnet()
    {
        float powerUpDistance = Vector3.Distance(playerTransform.position, powerUpTransform.position);
        Debug.Log(powerUpDistance);
        if (powerUpDistance < 1.5)
        {
            Debug.Log("magnet");
        }
    }
}
