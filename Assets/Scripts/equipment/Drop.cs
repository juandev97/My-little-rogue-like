using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    
    public static string TAG = "collectable";
    static System.Random rnd = new System.Random();
    SpriteRenderer sprend;
    Rigidbody2D rgb;
    public IDroppable dropInfo;
    Vector3 origin;
    const float SQR_MOVE_DISTANCE = 1.5f;
    const float FACTOR_MOVE = 1f;
    const float TARGET_HEIGHT = 1f;
    const float INIT_DISTANCE = 0.3f;

    void Awake()
    {
        sprend = GetComponent<SpriteRenderer>();
        rgb = GetComponent<Rigidbody2D>();
        origin = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if((transform.position - origin).sqrMagnitude < SQR_MOVE_DISTANCE)
        {
            var diff = transform.position - origin;
            var dist = diff.magnitude;
            rgb.velocity = diff.normalized *FACTOR_MOVE/dist;
        }
        else
        {
            rgb.velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(IDroppable dropInfo)
    {
        this.dropInfo = dropInfo;
        //print(this.dropInfo);
        var s = dropInfo.GetSprite();
        // print(s);
        // print(sprend);
        sprend.sprite = s;
        var bounds = sprend.sprite.bounds;
        var factor = TARGET_HEIGHT / bounds.size.y;
        transform.localScale = new Vector3(factor,factor,factor);
        transform.position += Quaternion.Euler(0,0,rnd.Next()%360) * new Vector3(INIT_DISTANCE,0);
    }

    public void isPicked()
    {
        Destroy(gameObject);
    }
}
