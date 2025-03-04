using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    public static readonly string[] directions = { "N", "NW", "W", "SW", "S", "SE", "E", "NE" };

    Animator animatorBody;
    public Camera cam;
    public Animator animatorLegs;

    string mouseDirection;
    readonly int angleCount = directions.Length;


    private void Awake()
    {
        animatorBody = GetComponent<Animator>();
        mouseDirection = "SW";
    }

    public void SetDirection(Vector2 direction)
    {
        string animationBody = null;
        string animationLegs = null;
        Vector2 mousePos = Input.mousePosition;
        mousePos = new Vector2(mousePos.x - (cam.pixelWidth/2), mousePos.y - (cam.pixelHeight/2));
        mousePos = Vector2.ClampMagnitude(mousePos, 1);

        animationBody = "PB_IDLE_" + mouseDirection;
        int bodyDir = DirectionToIndex(mousePos, 8);
        mouseDirection = directions[bodyDir];

        if (direction.magnitude < .01f)
        {
            animationLegs = "PL_IDLE_" + mouseDirection;
        }
        else
        {
            int legDir = DirectionToIndex(direction, 8);
            legDir = CheckBackWalk(legDir, bodyDir);
            animationLegs = CheckStrafeWalk(legDir, bodyDir);
        }

        animatorLegs.Play(animationLegs);
        animatorBody.Play(animationBody);
    }

    public static int DirectionToIndex(Vector2 dir, int sliceCount)
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

        return Mathf.FloorToInt(stepCount);
    }

    public int CheckBackWalk(int legDir, int bodyDir)
    {
        for(int i = (bodyDir - 2); i < bodyDir + 3; i++)
        {
            if (Mod(i, angleCount) == legDir)
            {
                animatorLegs.SetFloat("BackWalk", 1);
                return legDir;
            }
        }

        animatorLegs.SetFloat("BackWalk", -1);
        return Mod(legDir+(angleCount/2), angleCount);

    }

    public string CheckStrafeWalk(int legDir, int bodyDir)
    {
        if(legDir == Mod(bodyDir + 2, angleCount))
        {
            return "PL_STRAFE_L_" + directions[bodyDir];
        }
        else if(legDir == Mod(bodyDir - 2, angleCount))
        {
            return "PL_STRAFE_R_" + directions[bodyDir];
        }
        return "PL_WALK_" + directions[legDir];
    }

    private int Mod(int x, int m)
    {
        return (x % m + m) % m;
    }
}

