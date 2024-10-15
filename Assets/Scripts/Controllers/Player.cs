using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;
    public Transform playerTransform;
    public Transform powerUpTransform;
    public Transform targetRight;
    public Transform targetLeft;
    public Transform targetUp;
    public Transform targetDown;

    public float accelerationTime = 1f;
    public float decelerationTime = 1f;
    public float maxSpeed = 7.5f;
    public float turnSpeed = 180f;

    private float acceleration;
    private float deceleration;
    private Vector3 currentVelocity;
    private float maxSpeedSqr;

    float powerUpScore = 0;

    float elapsedTime;

    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
        maxSpeedSqr = maxSpeed * maxSpeed;
    }

    void Update()
    {
        Debug.Log(powerUpScore);
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            moveDirection += Vector3.up;
        if (Input.GetKey(KeyCode.S))
            moveDirection += Vector3.down;
        
        if (Input.GetKey(KeyCode.D))
            moveDirection += Vector3.right;
        if (Input.GetKey(KeyCode.A))
            moveDirection += Vector3.left;

        if (moveDirection.sqrMagnitude > 0)
        {
            currentVelocity += Time.deltaTime * acceleration * moveDirection;
            if (currentVelocity.sqrMagnitude > maxSpeedSqr)
            {
                currentVelocity = currentVelocity.normalized * maxSpeed;
            }
        }
        else
        {
            Vector3 velocityDelta = Time.deltaTime * deceleration * currentVelocity.normalized;
            if (velocityDelta.sqrMagnitude > currentVelocity.sqrMagnitude)
            {
                currentVelocity = Vector3.zero;
            }
            else
            {
                currentVelocity -= velocityDelta;
            }
        }

        transform.position += currentVelocity * Time.deltaTime;
    }

   

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "powerup")
        {
            powerUpScore = powerUpScore + 1;
        }
        if (collision.gameObject.tag == "boosterRight")
        {
            currentVelocity = Vector3.zero;
            Debug.Log("boost");
            BoosterRight();
        }
        if (collision.gameObject.tag == "boosterLeft")
        {
            currentVelocity = Vector3.zero;
            Debug.Log("boost");
            BoosterLeft();
        }
        if (collision.gameObject.tag == "boosterUp")
        {
            currentVelocity = Vector3.zero;
            Debug.Log("boost");
            BoosterUp();
        }
        if (collision.gameObject.tag == "boosterDown")
        {
            currentVelocity = Vector3.zero;
            Debug.Log("boost");
            BoosterDown();
        }
    }

    public void BoosterRight()
    {
        Vector3 endPosition = new Vector3(playerTransform.position.x + 500, playerTransform.position.y);
        Vector3 startPosition = new Vector3(playerTransform.position.x, playerTransform.position.y);
        float boostSpeed = 3f;

        elapsedTime = 0;

        elapsedTime += Time.deltaTime;
        float percentageComplete = (elapsedTime / boostSpeed);
        playerTransform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

        // rotate toward rotation of target object
        var step = 360;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRight.rotation, step);
    }

    public void BoosterLeft()
    {
        Vector3 endPosition = new Vector3(playerTransform.position.x - 500, playerTransform.position.y);
        Vector3 startPosition = new Vector3(playerTransform.position.x, playerTransform.position.y);
        float boostSpeed = 3f;

        elapsedTime = 0;

        elapsedTime += Time.deltaTime;
        float percentageComplete = (elapsedTime / boostSpeed);
        playerTransform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

        // rotate toward rotation of target object
        var step = 360;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetLeft.rotation, step);
    }

    public void BoosterUp()
    {
        Vector3 endPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + 500);
        Vector3 startPosition = new Vector3(playerTransform.position.x, playerTransform.position.y);
        float boostSpeed = 3f;

        elapsedTime = 0;

        elapsedTime += Time.deltaTime;
        float percentageComplete = (elapsedTime / boostSpeed);
        playerTransform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

        // rotate toward rotation of target object
        var step = 360;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetUp.rotation, step);
    }

    public void BoosterDown()
    {
        Vector3 endPosition = new Vector3(playerTransform.position.x, playerTransform.position.y - 500);
        Vector3 startPosition = new Vector3(playerTransform.position.x, playerTransform.position.y);
        float boostSpeed = 3f;

        elapsedTime = 0;

        elapsedTime += Time.deltaTime;
        float percentageComplete = (elapsedTime / boostSpeed);
        playerTransform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

        // rotate toward rotation of target object
        var step = 360;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetDown.rotation, step);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
