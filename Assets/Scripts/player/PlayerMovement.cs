using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    [SerializeField]
    Vector2 mousePos;
    //  Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //  anim = GetComponent<Animator>();
    }
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //   anim.SetInteger("movement",(int)(movement.x+movement.y));

    }

    void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //get direction of mouse position
        RotateTowardsMouse();

    }

    /// <summary>
    /// Rotares the player game object towards where the mouse position is
    /// </summary>
    private void RotateTowardsMouse()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        // Sets the vector components to get the angle
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        // Sets the angle between the player position and the mouse position
        // angle = Atan(sin/cos) in radians, so it converts that value to degrees
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        // Finally, applies the rotation to the transform
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
