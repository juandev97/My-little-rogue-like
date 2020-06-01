using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    static System.Random rnd = new System.Random();
    private Rigidbody2D rgb;
    private Vector3 direction;
    public float speed;
    private GameObject player;
    public List<Equipment> dropObjects;
    public List<float> dropPercents;
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

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            DropAll();
            Destroy(gameObject);
        }
    }

    void DropAll()
    {
        int nEquips = dropObjects.Count;
        for(int i = 0; i < nEquips; ++i)
        {
            if (rnd.NextDouble() < dropPercents[i])
            {
                var drop = Instantiate(GameManager.instance.dropPrefab,transform.position,Quaternion.identity);
                drop.GetComponent<Drop>().Setup(dropObjects[i]);
            }
        }
        Destroy(gameObject);
    }

    void OnValidate()
    {
        
    }
}
