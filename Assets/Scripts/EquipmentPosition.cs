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
		
		InventoryController ic = GameObject.Find("Player").GetComponent<InventoryController>();
		if(!objectToEquip.activeSelf){
			
			if(ic.hasItem(objectToEquip.tag)){
				ic.EquipWeapon(null);
				objectToEquip.SetActive(true);
			} else {Debug.Log("Player doesn't have that item");}
		}
		else
		{
			if(!ic.hasItem(objectToEquip.tag)){
				ic.EquipWeapon(objectToEquip);
				objectToEquip.SetActive(false);
			} else {Debug.Log("Player already has that item");}
		}
    }

    override public void setText()
    {
        if (showText)
        {
            text = "Press Q button to equip ";

            objectName = objectToEquip.tag;
        } else
        {
            text = "";

            objectName = "";
        }
    }
}
