using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_puke : MonoBehaviour
{
    public Transform Goal;
    float rotSpeed = .5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 lookAtGoal = new Vector3(Goal.position.x,
                                       Goal.position.y,
                                       this.transform.position.y);

        Vector3 direction = lookAtGoal - this.transform.position;

        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg + 90f;
        Quaternion angleQ = Quaternion.AngleAxis(angle, Vector3.forward);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                    angleQ,
                                                    Time.deltaTime* rotSpeed);


    }
}
