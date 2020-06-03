using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerEquip : MonoBehaviour
{
    static Dictionary<Equipment.Type,int> EQUIP_IDS = new Dictionary<Equipment.Type, int>()
    {
        {Equipment.Type.Weapon,0},
        {Equipment.Type.Head,1},
        {Equipment.Type.Boots,2},
    };
    public float pickupDistanceToMouse;
    public List<Equipment> equipObjects;
    public List<GameObject> equipSlots;
    void Start()
    {   
        for(int i = 0; i < equipObjects.Count; ++i)
        {
            equipSlots[i].GetComponent<Slot>().OnEquipmentChanged(equipObjects[i]);
        }
    }

    void Update()
    {
        var mouseClicked = Input.GetMouseButtonDown(0);
        if (mouseClicked)
        {
            var dropsTouched = Utilities.MouseTouchedObjectsWithTag(Drop.TAG,pickupDistanceToMouse);
            if(dropsTouched.Count > 0)
            {
                Pickup(dropsTouched[0]);
            }
        }
    }

    void Pickup(GameObject equip)
    {
        var drop = equip.GetComponent<Drop>();
        IDroppable dropInfo = drop.dropInfo;
        if (dropInfo is Equipment)
        {
            Equipment newEquipInfo = (Equipment)dropInfo;
            int ubi = EQUIP_IDS[newEquipInfo.type];
            if(equipObjects[ubi] != null)
            {
                Throw(newEquipInfo.type);
            }
            equipObjects[ubi] = newEquipInfo;
            equipSlots[ubi].GetComponent<Slot>().OnEquipmentChanged(newEquipInfo);
            
        }
        drop.isPicked();
        
    }

    void Throw(Equipment.Type equipType)
    {
        int ubi = EQUIP_IDS[equipType];
        Equipment toDrop = equipObjects[ubi];
        equipObjects[ubi] = null;
        if(toDrop == null)
        {
            throw new System.Exception("Se ha solicitado soltar un elemento, pero era null");
        }
        else
        {
            var dropped = Instantiate(GameManager.instance.dropPrefab,transform.position,Quaternion.identity);
            dropped.GetComponent<Drop>().Setup(toDrop);
        }
    }

    void Reset()
    {
        pickupDistanceToMouse = .5f;
    }
}