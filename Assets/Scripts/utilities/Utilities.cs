using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    public static List<GameObject> MouseTouchedObjectsWithTag(string tag, float distanceToMouse = 2.5f)
    {
        float sqrDistanceToMouse = distanceToMouse * distanceToMouse;
        var gameObjects = GameObject.FindGameObjectsWithTag(tag);
        Debug.Log(gameObjects.Length);
        List<GameObject> nearObjects = new List<GameObject>();
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        foreach (var obj in gameObjects)
        {
            var objPos = obj.transform.position;
            objPos.z = 0;
            var diff = objPos - mousePos;
            if(diff.sqrMagnitude < sqrDistanceToMouse)
            {
                nearObjects.Add(obj);
            }
        }
        // nearObjects.Sort(Comparer<GameObject>.Create((GameObject obj1, GameObject obj2)=>
        // {
        //     var obj1Pos = obj1.transform.position;
        //     obj1Pos.z = 0;
        //     var diff1 = obj1Pos - mousePos;
        //     return 0;
        // }));
        return nearObjects;
    }
}