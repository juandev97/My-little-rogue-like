using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public Transform PlayerPosition;
    public float angleSpeed;
    Vector2 movement;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direccion = PlayerPosition.position - transform.position;
        float angle = angleSpeed * (Mathf.Atan2(direccion.y,direccion.x)* Mathf.Rad2Deg -90);
        rb.rotation = angle;
        direccion.Normalize();
        movement = direccion;
    }

        void FixedUpdate()
    {   
        moveCharacter(movement);
    }
    
    
    void moveCharacter(Vector2 direccion){
        rb.MovePosition((Vector2) transform.position + (direccion * speed * Time.deltaTime));
    }

    
}
