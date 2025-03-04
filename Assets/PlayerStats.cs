using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int StartLevel;
    public int StartLifeMax;
    public int StartLife;
    public int StartManaMax;
    public int StartMana;
    public int StartStaminaMax;
    public int StartStamina;
    public int StartSpeed;
    public int StartIntelligence;
    public int StartStrength;
    public int StartDexterity;
    public float StartAttack;
    public float StartAttackSpeed;
    public float StartMagicAttack;
    public float StartCastSpeed;
    public float StartCriticalChance;
    public float StartCriticalDamage;
    public float StartArmor;
    public float StartResistance;
    public Dictionary<string, float> Stats = new Dictionary<string, float>();
    public Dictionary<string, string> Stringified;

    // Start is called before the first frame update
    void Awake()
    {
        Stats = new Dictionary<string, float>() {
            {"Level", StartLevel},
            {"LifeMax", StartLifeMax},
            {"Life", StartLife},
            {"ManaMax", StartManaMax},
            {"Mana", StartMana},
            {"StaminaMax", StartStaminaMax},
            {"Stamina", StartStamina},
            {"Speed", StartSpeed},
            {"Intelligence", StartIntelligence},
            {"Strength", StartStrength},
            {"Dexterity", StartDexterity},
            {"Attack", StartAttack},
            {"AttackSpeed", StartAttackSpeed},
            {"MagicAttack", StartMagicAttack},
            {"CastSpeed", StartCastSpeed},
            {"CriticalChance", StartCriticalChance},
            {"CriticalDamage", StartCriticalDamage},
            {"Armor", StartArmor},
            {"Resistance", StartResistance}
        };                                   

        Stringified = new Dictionary<string, string>()
        {
            {"Level", "Level"},
            {"LifeMax", "Maximum Life"},
            {"Life", "Current Life"},
            {"ManaMax", "Maximum Mana"},
            {"Mana", "Current Mana"},
            {"StaminaMax", "Maximum Stamina"},
            {"Speed", "Movement Speed"},
            {"Intelligence", "Intelligence"},
            {"Strength", "Strength"},
            {"Dexterity", "Dexterity"},
            {"Attack", "Attack Damage"},
            {"AttackSpeed", "Attack Speed"},
            {"MagicAttack", "Magic Damage"},
            {"CastSpeed", "Cast Speed"},
            {"CriticalChance", "Critical Strike Chance"},
            {"CriticalDamage", "Critical Strike Damage"},
            {"Armor", "Armor"},
            {"Resistance", "Resistance"}
        };
    }

    public void updateStats(Dictionary<string, float> addStats)
    {
        foreach(KeyValuePair<string, float> kvp in addStats) 
        {
            Stats[kvp.Key] += kvp.Value;
        }
    }
}
