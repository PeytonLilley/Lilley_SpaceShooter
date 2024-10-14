using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PowerUp : MonoBehaviour
{

    public Transform playerTransform;
    public Transform powerUpTransform;
    public float powerUpDistance;
    public float speed = 1;
    float elapsedTime;

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
       // Debug.Log(powerUpDistance);

        if (powerUpDistance < 2)
        {
            Debug.Log("magnet");

            Vector3 endPosition = playerTransform.position;
            Vector3 startPosition = powerUpTransform.position;
            float lerpSpeed = 7f;
        
            elapsedTime += Time.deltaTime;
            float percentageComplete = (elapsedTime / lerpSpeed);
            powerUpTransform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

}
