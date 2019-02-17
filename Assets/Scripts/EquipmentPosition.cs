using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPosition : ObjectInteraction
{
    public GameObject objectToEquip;
    private bool showText = true;

    override public void interact()
    {
        showText = false;
        objectToEquip.SetActive(!objectToEquip.activeSelf);
    }

    override public void setText()
    {
        if (showText)
        {
            text = "Press Q button to equip ";

            objectName = objectToEquip.name;
        } else
        {
            text = "";

            objectName = "";
        }
    }
}
