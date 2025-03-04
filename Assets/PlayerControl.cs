using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UIElements;

public class playerControl : MonoBehaviour
{

    public float movementSpeed = 1.0f;
    PlayerRenderer playerRenderer;
    PlayerWeapon playerWeapon;
    GroundSlam currSkill;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponentInChildren<PlayerRenderer>();
        playerWeapon = GetComponentInChildren<PlayerWeapon>();
        currSkill = GetComponentInChildren<GroundSlam>();
    }

    void FixedUpdate()
    {
        Vector2 currentPos = rb.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.deltaTime;
        playerRenderer.SetDirection(movement);
        rb.MovePosition(newPos);
    }
    void Update()
    {
        Vector2 currentPos = rb.position;
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            playerWeapon.AttackAt(currentPos, mousePosition);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currSkill.AttackAt(currentPos, mousePosition);
        }
    }
}
