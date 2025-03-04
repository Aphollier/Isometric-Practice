using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public PlayerStats stats;
    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject helmet;
    public GameObject chest;
    public GameObject gloves;
    public GameObject boots;
    public GameObject ring1;
    public GameObject ring2;
    public GameObject amulet;
    public GameObject belt;
    public GameObject passive;
    List<GameObject> passives = new List<GameObject>();
    public void setGear(SpriteRenderer sprite, string position, string toolTip, string name, bool equipped)
    {
        switch (position)
        {
            case "weapon":
                setEquipment(sprite, weapon1, toolTip, name, equipped);
                break;
            case "helmet":
                setEquipment(sprite, helmet, toolTip, name, equipped);
                break;
            case "chest":
                setEquipment(sprite, chest, toolTip, name, equipped);
                break;
            case "boots":
                setEquipment(sprite, boots, toolTip, name, equipped);
                break;
            case "gloves":
                setEquipment(sprite, gloves, toolTip, name, equipped);
                break;
            case "ring":
                setEquipment(sprite, ring1, toolTip, name, equipped);
                break;
            case "amulet":
                setEquipment(sprite, amulet, toolTip, name, equipped);
                break;
            case "belt":
                setEquipment(sprite, belt, toolTip, name, equipped);
                break;
            case "passive":
                setPassive(sprite, toolTip, name);
                break;
        }
    }

    private void setPassive(SpriteRenderer sprite, string toolTip, string name)
    {
        GameObject currPassive = new GameObject(sprite.name);
        passives.Add(currPassive);
        currPassive.transform.parent = passive.transform;
        Image passiveImage = currPassive.AddComponent<Image>();
        passiveImage.sprite = sprite.sprite;
        passiveImage.transform.localScale = new Vector3(1, 1, 1);
        passiveImage.rectTransform.sizeDelta = new Vector2(45, 45);
        passiveImage.rectTransform.anchoredPosition = new Vector3(-437 + (((passives.Count - 1)%10) * 45), 337 - ((int)((passives.Count - 1) / 10) * 45), 0);
        HoverTip hover = currPassive.AddComponent<HoverTip>();
        hover.Tip = toolTip;
        hover.Name = name;
        hover.Equiped = true;
        hover.Equip = "passive";
        ItemStats itemStats = currPassive.AddComponent<ItemStats>();
        itemStats.stats = stats;
        itemStats.addStats(toolTip);
    }

    private void setEquipment(SpriteRenderer sprite, GameObject equipment, string toolTip, string name, bool equipped)
    {
        Image gearImage = equipment.GetComponent<Image>();
        ItemStats itemStats = equipment.GetComponent<ItemStats>();
        HoverTip hover = equipment.GetComponent<HoverTip>();
        if (hover.Equiped)
        {
            dropEquipment(gearImage, itemStats, hover);
        }
        if (!equipped)
        {
            gearImage.sprite = sprite.sprite;
            gearImage.color = Color.white;
            hover.Tip = toolTip;
            hover.Name = name;
            hover.Equiped = true;
            itemStats.addStats(toolTip);
        }
    }

    private void dropEquipment(Image gearImage, ItemStats itemStats, HoverTip hover)
    {
        Sprite tempSprite = gearImage.sprite;
        string tempTip = hover.Tip;
        string tempName = hover.Name;
        gearImage.sprite = null;
        gearImage.color = Color.clear;
        hover.Tip = "";
        hover.Name = "";
        hover.Equiped = false;
        itemStats.removeStats();
        GameObject newDrop = new GameObject(tempName);
        SpriteRenderer sprite = newDrop.AddComponent<SpriteRenderer>();
        HoverTip newHover = newDrop.AddComponent<HoverTip>();
        BoxCollider2D collider = newDrop.AddComponent<BoxCollider2D>();
        Vector3 pos = stats.transform.position;
        newDrop.transform.position = new Vector3(pos.x + Random.Range(-(float)0.3, (float)0.3), pos.y + Random.Range(-(float)0.3, (float)0.3), pos.z); ;
        sprite.sprite = tempSprite;
        sprite.sortingOrder = 1;
        newDrop.transform.localScale = new Vector3((float)0.2, (float)0.2, 1);
        newHover.Tip = tempTip;
        newHover.Name = tempName;
        newHover.Equip = hover.Equip;
        collider.isTrigger = true;
        collider.size = new Vector2(1, 1);
    }
}
