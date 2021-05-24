using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem_R : MonoBehaviour
{
    public bool isAnimated = false;
    public bool isRotating = false;

    public bool bluerotation = false;

    public Vector3 rotationAngle;
    public float rotationSpeed;



    
    // Start is called before the first frame update
    void Start()
    {
        if(bluerotation)
        {
            transform.eulerAngles = new Vector3(-90, 0, 0);
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isAnimated)
        {
            if(isRotating)
            {
                transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
            }
        }
    }
}
