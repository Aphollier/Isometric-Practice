using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillsBars : MonoBehaviour
{
    public Image HealthFill;
    public Image ManaFill;
    public Image StaminaFill;
    public PlayerStats Stats;

    void Update()
    {
        float healthPercent = Stats.Stats["Life"] / Stats.Stats["LifeMax"];
        float manaPercent = Stats.Stats["Mana"] / Stats.Stats["ManaMax"];
        float staminaPercent = Stats.Stats["Stamina"] / Stats.Stats["StaminaMax"];
        HealthFill.fillAmount = healthPercent;
        ManaFill.fillAmount = manaPercent;
        StaminaFill.fillAmount = staminaPercent;
    }
}
