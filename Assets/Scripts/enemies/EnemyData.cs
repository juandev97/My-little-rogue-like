using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy Object")]
public class EnemyData : ScriptableObject
{
    [System.Serializable]
    public class DropProb
    {
        public Equipment dropObject;
        public float dropPercent;
    }
    public int id;
    public Sprite sprite;
    public Color color;
    public int life;
    public float speed;
    public List<DropProb> drops;
    //public List<Equipment> dropObjects;
    //public List<float> dropPercents;
}