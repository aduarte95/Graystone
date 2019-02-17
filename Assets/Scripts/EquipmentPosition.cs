using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPosition : ObjectInteraction
{
    public GameObject objectToEquip;

    override public void interact()
    {
        if (objectToEquip.activeSelf)
        {
            objectToEquip.SetActive(!objectToEquip.activeSelf);
        }
    }

    override public void setText()
    {
        text = "Press Q button to equip ";
   
        objectName = objectToEquip.name;
    }
}
