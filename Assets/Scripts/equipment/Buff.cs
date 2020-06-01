using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Buff
{
    public enum Type
    {
        Health, Attack, Defense
    }
    public Type type;
    public float value;
}
