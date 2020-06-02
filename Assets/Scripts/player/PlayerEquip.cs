using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerEquip : MonoBehaviour
{

    public float pickupDistanceToMouse;

    public Equipment arm,head,feet;
    
    public GameObject armSlot, headSlot, feetSlot;
    void Start()
    {   
        armSlot.GetComponent<Slot>().OnEquipmentChanged(arm);
        headSlot.GetComponent<Slot>().OnEquipmentChanged(head);
        feetSlot.GetComponent<Slot>().OnEquipmentChanged(feet);
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
            switch (newEquipInfo.type)
            {
                case Equipment.Type.Weapon:
                    if (arm != null)
                    {
                        Throw(Equipment.Type.Weapon);
                    }
                    arm = newEquipInfo;
                    armSlot.GetComponent<Slot>().OnEquipmentChanged(newEquipInfo);
                    break;
                case Equipment.Type.Head:
                    if (head != null)
                    {
                        Throw(Equipment.Type.Head);
                    }
                    head = newEquipInfo;
                    headSlot.GetComponent<Slot>().OnEquipmentChanged(newEquipInfo);
                    break;
                case Equipment.Type.Boots:
                    if (feet != null)
                    {
                        Throw(Equipment.Type.Boots);
                    }
                    feet = newEquipInfo;
                    feetSlot.GetComponent<Slot>().OnEquipmentChanged(newEquipInfo);
                    break;
                default:
                    break;
            }
            
        }
        drop.isPicked();
        
    }

    void Throw(Equipment.Type equipType)
    {
        Equipment toDrop = null;
        switch(equipType)
        {
            case Equipment.Type.Weapon:
                toDrop = arm;
                arm = null;
                break;
            case Equipment.Type.Head:
                toDrop = head;
                head = null;
                break;
            case Equipment.Type.Boots:
                toDrop = feet;
                feet = null;
                break;
            default:
                break;
        }
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