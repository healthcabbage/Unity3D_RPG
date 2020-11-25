using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeUI : MonoBehaviour
{
    public GameObject SkilltreePanel;

    public bool activeskilltree = false;

    // Start is called before the first frame update
    private void Start()
    {
        SkilltreePanel.SetActive(activeskilltree);
    }

    public void Open()
    {
        activeskilltree = !activeskilltree;
        SkilltreePanel.SetActive(activeskilltree);
    }
}
