using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlot : MonoBehaviour
{
    [SerializeField] private Slot[] quickSlots; //퀵슬롯들 (총 6개)
    [SerializeField] private Transform tf_parent; // 퀵슬롯의 부모 오브젝트

    void Start()
    {
        //quickSlots = tf_parent.GetComponentsInChildren<Slot>();
    }

    void Update()
    {

    }

    private void TryInputNumber()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
    }

    
}
