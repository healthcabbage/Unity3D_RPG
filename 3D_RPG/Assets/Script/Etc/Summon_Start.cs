using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon_Start : MonoBehaviour
{
    int charactors;
    public GameObject []character = new GameObject[2];
    GameObject respawn = null;
    // Start is called before the first frame update
    void Start()
    {
        charactors = SelectLight.characterNum;
        respawn = GameObject.FindGameObjectWithTag("Respawn");

        for (int i = 0; i<4; i++)
        {
            if (charactors == i)
            {
                Instantiate(character[i], respawn.transform.position, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
