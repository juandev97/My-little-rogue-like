using UnityEngine;

public class Level_generator : MonoBehaviour {
    public GameObject roomLayout;
    public Color StartColor, EndColor;

    public Transform generatorPoint;

    public int distanceToEnd;

    public enum Direction {up, right, down, left};
    public Direction selectedDirection;

    public float Xoffset=23f,Yoffset=15f;
    private void Start() {
        Instantiate(roomLayout, generatorPoint.position ,generatorPoint.rotation).GetComponent<SpriteRenderer>().color = StartColor;
        selectedDirection = (Direction) Random.Range(0,4);
        MoveGenerationPoint();

        for(int i=0; distanceToEnd >= i; i++){
            Instantiate(roomLayout, generatorPoint.position ,generatorPoint.rotation);
            selectedDirection = (Direction) Random.Range(0,4);
            MoveGenerationPoint(); 
            
            //ULTIMA SALA 
            if(i == distanceToEnd){
                    Instantiate(roomLayout, generatorPoint.position ,generatorPoint.rotation).GetComponent<SpriteRenderer>().color = EndColor;
    
            }
        }

    }

    private void Update() {
        
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