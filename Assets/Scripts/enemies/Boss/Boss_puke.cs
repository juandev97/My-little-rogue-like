using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_puke : MonoBehaviour
{

   public float fuerza;
    public Transform Goal;
    float rotSpeed = .82f;
    public float maxDist;
    public LayerMask whatIs;
    public bool auxiliarPuke;
    public SpriteRenderer vomito;
    [SerializeField]
    float vomitValue;
    Animator anim;
    float auxiliarFuerza;
    // Start is called before the first frame update
    void Start()
    {
        vomitValue = maxDist/5;
        auxiliarFuerza = fuerza;
        anim = GetComponent<Animator>();
    }


    IEnumerator vomitanding(float i){
        yield return new  WaitForSeconds(.08f);
        vomito.size = new Vector2(.32f,i);
        yield return new  WaitForSeconds(4f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        puke(anim.GetBool("Boss_puke")); 
    }

    void puke(bool statePuke){
        if (!statePuke && auxiliarPuke){

        fuerza = auxiliarFuerza;
        for(float i=0f;i<=vomitValue;i+=.01f){

        StartCoroutine(vomitanding(i));
        }


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
    }else{
        StartCoroutine(vomitanding(0));
        fuerza =0f;
    }
    }
}
