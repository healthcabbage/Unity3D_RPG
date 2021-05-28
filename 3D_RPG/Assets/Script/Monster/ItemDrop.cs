using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject[] items = new GameObject[2];

    public GameObject pos;

    private bool OneDrop;
    void Start()
    {
        OneDrop = false;
    }

    public void DropItem()
    {
        if (!OneDrop)
        {
            int rand = Random.Range(0, 2);
            Instantiate(items[rand], pos.transform.position, Quaternion.identity);
            OneDrop = true;
        }
    }
}
