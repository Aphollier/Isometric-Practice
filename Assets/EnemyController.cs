using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UIElements;

public class enemyController : MonoBehaviour
{

    public float movementSpeed = 1.0f;
    EnemyRender enemyRender;
    Rigidbody2D rb;
    public Rigidbody2D target;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyRender = GetComponentInChildren<EnemyRender>();
    }

    void FixedUpdate()
    {
        Vector2 currentPos = rb.position;
        Vector2 targetPos = target.position;
        Vector2 playerVector =  targetPos - currentPos;
        playerVector = Vector2.ClampMagnitude(playerVector, 1);
        Vector2 movement = playerVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.deltaTime;
        enemyRender.SetDirection(movement);
        rb.MovePosition(newPos);
    }
}
