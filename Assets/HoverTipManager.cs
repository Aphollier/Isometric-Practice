using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class HoverTipManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI tipText;
    public RectTransform toolTip;
    public RectTransform nameSlot;
    public RectTransform tipSlot;
    public InventorySystem inventorySystem;
    public PlayerStats playerStats;

    public static Action<string, string, Vector3> OnMouseHover;
    public static Action OnMouseDrop;
    public static Action<SpriteRenderer, string, string, string, bool> OnMouseClick;

    private void OnEnable()
    {
        OnMouseHover += ShowTip;
        OnMouseDrop += HideTip;
        OnMouseClick += AddToInventory;
    }

    private void OnDisable()
    {
        OnMouseHover -= ShowTip;
        OnMouseDrop -= HideTip;
        OnMouseClick -= AddToInventory;
    }

    void Start()
    {
        HideTip();
    }

    private void ShowTip(string tip, string name, Vector3 mousePos)
    {
        if (name != "") {
            tipText.text = fixText(tip);
            nameText.text = name;
            tipSlot.sizeDelta = new Vector2(200, tipText.preferredHeight);
            toolTip.gameObject.SetActive(true);
            toolTip.position = new Vector2(mousePos.x + (float)0.1, mousePos.y);
        }
    }

    private void HideTip()
    {
        tipText.text = default;
        toolTip.gameObject.SetActive(false);
    }

    private void AddToInventory(SpriteRenderer Sprite, string Position, string ToolTip, string Name, bool Equipped)
    {
        inventorySystem.setGear(Sprite, Position, ToolTip, Name, Equipped);
    }

    private string fixText(string text)
    {
        string fixedText = "";
        string[] divided = text.Split('|');
        foreach (string s in divided)
        {
            string[] split = s.Split(' ');
            if (playerStats.Stringified.ContainsKey(split[0]))
            {
                fixedText += playerStats.Stringified[split[0]];
                if (double.Parse(split[1]) < 0)
                {
                    fixedText += " - ";
                }
                else
                {
                    fixedText += " + ";
                }
                fixedText += split[1] + "\n";
            }
            else
            {
                fixedText = text;
            }
        }
        return fixedText;
    }

}
