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

    public OutlinePrefabs outlinePrefab;
    public float Xoffset=23f,Yoffset=15f;

    private GameObject endRoom;

     private List<GameObject> lista_outlines = new List<GameObject>();

    private List<GameObject> lista_rooms = new List<GameObject>();

    private void Start() {
        
        Instantiate(roomLayout, generatorPoint.position ,generatorPoint.rotation).GetComponent<SpriteRenderer>().color = StartColor;
        selectedDirection = (Direction) UnityEngine.Random.Range(0,4);
        MoveGenerationPoint();

        for(int i=0; distanceToEnd >= i; i++)
        {
            GameObject newRoom = Instantiate(roomLayout, generatorPoint.position ,generatorPoint.rotation);
            
            lista_rooms.Add(newRoom);

            selectedDirection = (Direction) UnityEngine .Random.Range(0,4);
            MoveGenerationPoint(); 
            
            while(Physics2D.OverlapCircle(generatorPoint.position, 2f, whatIsRoom))
            {
                MoveGenerationPoint();
            }
            //ULTIMA SALA 
            if(i == distanceToEnd -1)
            {
                    
                newRoom.GetComponent<SpriteRenderer>().color = EndColor;
                lista_rooms.RemoveAt(lista_rooms.Count - 1);
                endRoom = newRoom;
            }

        }


    //creamos paredes
        CreateRoomOutline(Vector3.zero);
        foreach(GameObject room in lista_rooms)
        {
            CreateRoomOutline(room.transform.position);
        }
        CreateRoomOutline(endRoom.transform.position);

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

     public void CreateRoomOutline(Vector3 roomPoosition){
        bool roomAbove = Physics2D.OverlapCircle(roomPoosition + new Vector3(0f,Yoffset,0f), .2f, whatIsRoom);
        bool roomBelow = Physics2D.OverlapCircle(roomPoosition + new Vector3(0f,-Yoffset,0f), .2f, whatIsRoom);
        bool roomLeft = Physics2D.OverlapCircle(roomPoosition + new Vector3(-Xoffset,0f,0f), .2f, whatIsRoom);
        bool roomRight = Physics2D.OverlapCircle(roomPoosition + new Vector3(Xoffset,0f,0f), .2f, whatIsRoom);
        
        int Nhcount = 0;
        
        if(roomAbove){
            Nhcount ++;
        }if(roomBelow){
            Nhcount ++;
        }if(roomRight){
            Nhcount ++;
        }if(roomLeft){
            Nhcount ++;
        }

        switch(Nhcount){
            case 0:
                Debug.LogError("No room exists!");
                break;
            case 1:
                if(roomAbove){
                    lista_outlines.Add(Instantiate(outlinePrefab.sUp, roomPoosition,Quaternion.identity));
                }
                if(roomBelow){
                    lista_outlines.Add(Instantiate(outlinePrefab.sDown, roomPoosition,Quaternion.identity));
                }
                if(roomRight){
                    lista_outlines.Add(Instantiate(outlinePrefab.sRight, roomPoosition,Quaternion.identity));
                }
                if(roomLeft){
                    lista_outlines.Add(Instantiate(outlinePrefab.sLeft, roomPoosition,Quaternion.identity));
                }

                break;

            case 2:
                if(roomAbove && roomBelow){
                    lista_outlines.Add(Instantiate(outlinePrefab.dUD, roomPoosition,Quaternion.identity));
                }
                if(roomRight && roomLeft){
                    lista_outlines.Add(Instantiate(outlinePrefab.dLR, roomPoosition,Quaternion.identity));
                }

                if(roomRight && roomAbove){
                    lista_outlines.Add(Instantiate(outlinePrefab.dUR, roomPoosition,Quaternion.identity));
                }
                if(roomLeft && roomAbove){
                    lista_outlines.Add(Instantiate(outlinePrefab.dLU, roomPoosition,Quaternion.identity));
                }

                if(roomRight && roomBelow){
                    lista_outlines.Add(Instantiate(outlinePrefab.dRD, roomPoosition,Quaternion.identity));
                }
                if(roomLeft && roomBelow){
                    lista_outlines.Add(Instantiate(outlinePrefab.dLD, roomPoosition,Quaternion.identity));
                }

                break;
            case 3:
                if(roomAbove && roomBelow && roomRight){
                    lista_outlines.Add(Instantiate(outlinePrefab.tURD, roomPoosition,Quaternion.identity));
                }
                if(roomRight && roomLeft && roomAbove){
                    lista_outlines.Add(Instantiate(outlinePrefab.tLUR, roomPoosition,Quaternion.identity));
                }

                if(roomRight && roomLeft && roomBelow){
                    lista_outlines.Add(Instantiate(outlinePrefab.tLDR, roomPoosition,Quaternion.identity));
                }
                if(roomAbove && roomBelow && roomLeft){
                    lista_outlines.Add(Instantiate(outlinePrefab.tLUD, roomPoosition,Quaternion.identity));
                }
                break;
            case 4:
                lista_outlines.Add(Instantiate(outlinePrefab.A, roomPoosition,Quaternion.identity));
                break;
        }
    }
}

[System.Serializable]
public class OutlinePrefabs {
    public GameObject sUp,sDown,sRight,sLeft,
    dLR,dUD,dUR,dLU,dRD,dLD,
    tLUD,tLDR,tURD,tLUR,
    A;
}