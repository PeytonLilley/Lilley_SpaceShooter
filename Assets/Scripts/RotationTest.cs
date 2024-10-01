using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public float AngularSpeed = 30f;
    public float targetAngle = 130f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, transform.up, Color.green);
        float currentRotation = transform.rotation.eulerAngles.z + 90;
        
        Debug.Log(currentRotation);

        if (currentRotation < targetAngle)
        {
            transform.Rotate(0, 0, AngularSpeed * Time.deltaTime);
        }
        else if (currentRotation > targetAngle)
        {
            transform.Rotate(0, 0, -AngularSpeed * Time.deltaTime);
        }
    }

    public float StandardizeAngle(float inAngle)
    {
        inAngle %= 360;

        if (inAngle >180)
        {
            inAngle -= 360;
        }

        return inAngle;
    }
}
