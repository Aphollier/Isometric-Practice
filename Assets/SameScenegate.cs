using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameScenegate : MonoBehaviour
{
    public float x;
    public float y;
    public bool lightSwitch;
    public GameObject lightObj;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.localPosition = new Vector3(x, y, 0);
        if (lightSwitch)
        {
            lightObj.SetActive(!lightObj.activeSelf);
        }
    }
}
