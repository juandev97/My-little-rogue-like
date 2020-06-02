using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    const string LINEAL = "LINEAL";
    const string REFLECTED_COSINE_AND_SINE = "REFLECTED_COSINE_AND_SINE";
    const string INVERTED_COSINE = "INVERTED_COSINE";
    
    bool movingCamera;
    float dx,dy;
    int CAMERA_MOVE_STEPS = 80;
    int step = 0;
    Vector3 startCamera;
    Vector3 endCamera;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        endCamera = transform.position;
        movingCamera = false;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (movingCamera)
        {
            ++step;
            
            Camera.main.GetComponent<Transform>().position =
                        GetPointInTransition(startCamera,endCamera,step,CAMERA_MOVE_STEPS,
                                                LINEAL);
            if(step == CAMERA_MOVE_STEPS)
            {
                movingCamera = false;
            }
        }
    }

    public void MoveCamera(float dx, float dy, float pdx, float pdy)
    {
        startCamera = endCamera;
        endCamera = startCamera + new Vector3(dx,dy);
        player.transform.position += new Vector3(pdx,pdy);
        movingCamera = true;
        step = 0;
    }

    Vector3 GetPointInTransition(Vector3 start, Vector3 end, int step, int maxStep, string transition = "LINEAL")
    {
        Vector3 diffCameraPos = endCamera - startCamera; 
        switch(transition)
        {
        case LINEAL:
            return startCamera + diffCameraPos * step / CAMERA_MOVE_STEPS;
        case REFLECTED_COSINE_AND_SINE:
            if(true || step <= maxStep/2)
            {
                return startCamera + diffCameraPos * (0.5f-(Mathf.Cos((Mathf.PI / 2) * step * 2 / CAMERA_MOVE_STEPS)) / 2f);
            }else{
                return startCamera + diffCameraPos * (0.5f+(Mathf.Sin((Mathf.PI / 2) * ((step / CAMERA_MOVE_STEPS)-0.5f) * 2)/2));
            }
        case INVERTED_COSINE:
            return startCamera + diffCameraPos * (1-(Mathf.Cos((Mathf.PI / 2) * step / CAMERA_MOVE_STEPS)));
        default:
            return new Vector3(0,0);
        }
    }

}
