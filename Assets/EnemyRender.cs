using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRender : MonoBehaviour
{
    public static readonly string[] directions = { "N", "NW", "W", "SW", "S", "SE", "E", "NE" };

    Animator animatorBody;
    public Animator animatorLegs;

    string lastDirection;


    private void Awake()
    {
        animatorBody = GetComponent<Animator>();
        lastDirection = "SW";
    }

    public void SetDirection(Vector2 direction)
    {
        string animationBody = null;
        string animationLegs = null;

        if (direction.magnitude < .01f)
        {
            animationLegs = "PL_IDLE_" + lastDirection;
        }
        else
        {
            animationLegs = "PL_WALK_" + lastDirection;
            lastDirection = DirectionToIndex(direction, 8);
        }

        animationBody = "PB_IDLE_" + lastDirection;

        animatorLegs.Play(animationLegs);
        animatorBody.Play(animationBody);
    }

    public static string DirectionToIndex(Vector2 dir, int sliceCount)
    {
        Vector2 normDir = dir.normalized;
        float step = 360f / sliceCount;
        float halfstep = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        angle += halfstep;
        if (angle < 0)
        {
            angle += 360;
        }

        float stepCount = angle / step;

        return directions[Mathf.FloorToInt(stepCount)];
    }
}
