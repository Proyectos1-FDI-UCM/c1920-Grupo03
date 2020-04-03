using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashDistanceMax = 2f;
    public GameObject raycastOrigin;

    Rigidbody2D playerRigidbody;
    float dashDistance;
    Vector2 playerDir;
    bool dashPressed;

    RaycastHit2D raycastResult;

    private void Awake()
    {
        dashPressed = false;
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Dash") && !dashPressed) dashPressed = true;
    }

    private void FixedUpdate()
    {
        playerDir = playerRigidbody.velocity.normalized;

        if (dashPressed)
        {
            if (playerDir.magnitude != 0) Call();
            dashPressed = false;
        }
    }

    void Call()
    {
        raycastResult = Physics2D.Raycast(raycastOrigin.transform.position, playerDir, dashDistanceMax);

        Collider2D other = raycastResult.collider;
        Vector2 distanceVector;

        if (other != null)
        {
            Debug.Log("Collider Found");

            distanceVector.x = raycastResult.point.x - raycastOrigin.transform.position.x;
            distanceVector.y = raycastResult.point.y - raycastOrigin.transform.position.y;
            dashDistance = distanceVector.magnitude;
        }

        else dashDistance = dashDistanceMax;

        playerRigidbody.position = new Vector2(playerRigidbody.position.x + playerDir.x * dashDistance, playerRigidbody.position.y + playerDir.y * dashDistance);
    }

}
