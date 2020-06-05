using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_puke : MonoBehaviour
{

   public float fuerza;
    public Transform Goal;
    float rotSpeed = .7f;
    public float maxDist;
    public LayerMask whatIs;
    public SpriteRenderer vomito;
    [SerializeField]
    float vomitValue;
    // Start is called before the first frame update
    void Start()
    {
        for(float i=0;i<vomitValue;i+=.1f){

        StartCoroutine(vomitanding(i));
        }
    }


    IEnumerator vomitanding(float i){
        yield return new  WaitForSeconds(2f);
        vomito.size = new Vector2(.32f,i);
        yield return new  WaitForSeconds(2f);
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
        

        Vector3 adelante = transform.TransformDirection(Vector2.down);
        RaycastHit2D hit = Physics2D.Raycast(transform.position,adelante, maxDist,whatIs);
        Debug.DrawRay(transform.position, adelante*maxDist, Color.red,2f);
        Collider2D[] col = Physics2D.OverlapPointAll(adelante);
        if(hit)
        {
            Debug.Log("hit " + hit.collider.name);
            if(hit.collider.tag == "Player"){
                hit.collider.transform.position+=adelante*fuerza*Time.deltaTime;
            }
        }
    }
}
