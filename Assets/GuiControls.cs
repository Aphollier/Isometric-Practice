using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiControls : MonoBehaviour
{
    public GameObject Inventory;

    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            Inventory.SetActive(!Inventory.activeSelf);
        }
    }
}
