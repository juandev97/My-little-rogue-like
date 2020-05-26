using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rgb;
    private Vector3 direction;
    public float speed;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        speed = (speed == 0f)? 1.5f: speed;
        rgb = GetComponent<Rigidbody2D>();
        direction = new Vector3(0,0);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 diff = player.transform.position - transform.position;
        diff.z = 0;
        diff.Normalize();
        rgb.velocity = diff*speed;
    }
}
