using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Drop : MonoBehaviour
{

    public static readonly string[] equipment = { "Helmet", "Chest", "Gloves", "Boots", "Ring", "Amulet", "Belt", "Passive", "Weapon" };
    private static Dictionary<string, int> statRolls = new Dictionary<string, int>()
    {
        {"LifeMax", 80},
        {"ManaMax", 80},
        {"StaminaMax", 80},
        {"Speed", 5},
        {"Intelligence", 80},
        {"Strength", 80},
        {"Dexterity", 80},
        {"Attack", 5},
        {"AttackSpeed", 5},
        {"MagicAttack", 5},
        {"CastSpeed", 5},
        {"CriticalChance", 10},
        {"CriticalDamage", 80},
        {"Armor", 50},
        {"Resistance", 50}
    };
    public static void dropRandom(Vector3 pos)
    {
        string drop = equipment[Random.Range(0, equipment.Length - 1)];
        GameObject newDrop = Instantiate(Resources.Load<GameObject>(drop));
        newDrop.transform.position = new Vector3(pos.x + Random.Range(-(float)0.3, (float)0.3), pos.y + Random.Range(-(float)0.3, (float)0.3), pos.z);
        HoverTip hoverTip = newDrop.GetComponent<HoverTip>();
        string tip = "";
        List<int> chosen = new List<int>();
        List<string> stats = new List<string>(statRolls.Keys);
        for(int i = 0; i < 6; i++)
        {
            int stat = Random.Range(0, 19);
            if (!chosen.Contains(stat))
            {
                chosen.Add(stat);
                if (stat < 15)
                {
                    tip += stats[stat] + " " + Random.Range(1, statRolls[stats[stat]]) + "|";
                }
            }
        }
        hoverTip.Tip = tip.Remove(tip.Length - 1, 1);
    }
}
