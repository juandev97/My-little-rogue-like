using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    static string IMAGE_CHILD_NAME = "Image";


    public Equipment equipment;
    // Start is called before the first frame update
    void Start()
    {
        var img = transform.Find(IMAGE_CHILD_NAME).GetComponent<Image>();
        img.sprite = equipment.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
