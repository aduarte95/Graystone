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
			Debug.Log("A");
			ic.EquipWeapon(null);
			objectToEquip.SetActive(true);
		}
		else
		{
			Debug.Log("B");
			ic.EquipWeapon(objectToEquip);
			objectToEquip.SetActive(false);
		}
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
