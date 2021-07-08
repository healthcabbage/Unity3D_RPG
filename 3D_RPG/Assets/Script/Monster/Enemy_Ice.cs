using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ice : MonoBehaviour
{
    public int atk;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * 30 * Time.deltaTime);
    }
}
