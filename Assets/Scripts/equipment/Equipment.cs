using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "Equipment Object")]
public class Equipment : ScriptableObject, IDroppable
{
    public enum Type
    {
        Weapon, Head, Boots
    }
    public Type type;
    public List<Buff> buffs;
    public Sprite sprite;

    public Sprite GetSprite(){ return sprite; }
    public int GetAmount(){ return 0; }
}
