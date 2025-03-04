using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerWeapon : MonoBehaviour
{
    Animator Animator;
    public PlayerStats Stats;
    public int Damage;

    void Awake()
    {
        Animator = GetComponent<Animator>();
        Damage = Mathf.FloorToInt(Damage * Stats.Stats["Attack"]);
    }
    public void AttackAt(Vector2 playerPos, Vector2 mousePos)
    {
        Vector3 directionVector = Vector3.ClampMagnitude((mousePos - playerPos), (float)0.1);
        transform.localPosition = directionVector;
        float angle = Mathf.Atan2(directionVector.x, directionVector.y);
        transform.localRotation = Quaternion.Euler(0, 0, -angle * (180 / Mathf.PI));
        Animator.Play("Sword_Slash");
    }
}
