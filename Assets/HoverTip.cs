using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public string Name;
    public string Tip;
    public string Equip;
    public bool Equiped = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        HoverTipManager.OnMouseHover(Tip, Name, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HoverTipManager.OnMouseDrop();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        HoverTipManager.OnMouseClick(gameObject.GetComponent<SpriteRenderer>(), Equip, Tip, Name, Equiped);
        if (!Equiped )
        { 
            Destroy(gameObject);
        }
        HoverTipManager.OnMouseDrop();
    }

}

