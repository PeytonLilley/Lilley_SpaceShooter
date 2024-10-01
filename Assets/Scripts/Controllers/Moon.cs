using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    public float radius = 1;
    public float speed = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        OrbitalMotion(radius, speed, planetTransform);
    }
    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        radius = 1;
        speed = 10;
        transform.RotateAround(planetTransform.transform.position, Vector3.back, speed * Time.deltaTime);
    }
}
