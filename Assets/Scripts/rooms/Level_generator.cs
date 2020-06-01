using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Level_generator : MonoBehaviour {
    public GameObject roomLayout;
    public Color StartColor, EndColor;

    public Transform generatorPoint;

    public int distanceToEnd;

    public enum Direction {up, right, down, left};
    public Direction selectedDirection;


    public LayerMask whatIsRoom;

    public float Xoffset=23f,Yoffset=15f;

    private List<GameObject> lista = new List<GameObject>();

    private void Start() {
        
        Instantiate(roomLayout, generatorPoint.position ,generatorPoint.rotation).GetComponent<SpriteRenderer>().color = StartColor;
        selectedDirection = (Direction) UnityEngine.Random.Range(0,4);
        MoveGenerationPoint();

        for(int i=0; distanceToEnd >= i; i++){
            GameObject newRoom = Instantiate(roomLayout, generatorPoint.position ,generatorPoint.rotation);
            
            lista.Add(newRoom);

            selectedDirection = (Direction) UnityEngine .Random.Range(0,4);
            MoveGenerationPoint(); 
            
            while(Physics2D.OverlapCircle(generatorPoint.position, 2f, whatIsRoom))
            {
                MoveGenerationPoint();
            }
            //ULTIMA SALA 
            if(i == distanceToEnd -1){
                    
                newRoom.GetComponent<SpriteRenderer>().color = EndColor;
                lista.RemoveAt(lista.Count - 1);
            }
        }

    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void MoveGenerationPoint(){
        switch(selectedDirection)
        {
            case Direction.up:
                generatorPoint.position += new Vector3(0f,Yoffset,0f);
                break;
            case Direction.down:
                generatorPoint.position += new Vector3(0f,-Yoffset,0f);
                break;
            case Direction.right:
                generatorPoint.position += new Vector3(Xoffset,0f,0f);
                break;
            case Direction.left:
                generatorPoint.position += new Vector3(-Xoffset,0f,0f);
                break;
        }
    }
}