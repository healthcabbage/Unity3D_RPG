using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public bool activeinven= false;

    private void Start()
    {
        inventoryPanel.SetActive(activeinven);
    }

    public void Open()
    {
        activeinven = !activeinven;
        inventoryPanel.SetActive(activeinven);
    }
}
