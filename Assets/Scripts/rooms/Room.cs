using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Room : MonoBehaviour
{
    public List<GameObject> doorCollidersObj;
    bool activeRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    public void OnBorderTouched(string collName)
    {
        float dx = 0,dy = 0,pdx = 0,pdy = 0;
        switch(collName)
        {
        case "L":
            dx = -25; dy = 0;
            pdx = -8; pdy = 0;
            break;
        case "R":
            dx = 25; dy = 0;
            pdx = 8; pdy = 0;
            break;
        case "U":
            dx = 0; dy = 17;
            pdx = 0; pdy = 8;
            break;
        case "D":
            dx = 0; dy = -17;
            pdx = 0; pdy = -8;
            break;
        default:
            break;
        }
        activeRoom = false;
        Camera.main.GetComponent<RoomTransition>().MoveCamera(dx,dy,pdx,pdy);

    }

    
}
