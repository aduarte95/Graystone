using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public string weaponEquipped = "";
    public GameObject weaponSlot;
    public bool isHidden;
    private GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
		isHidden = true;
        inventory = GameObject.Find("Inventory");
		inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Behaviour
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (isHidden)
            {
                Debug.Log("Enabling inventory...");
                inventory.SetActive(true);
                isHidden = false;
            }
            else
            {
                Debug.Log("disabling inventory...");
                inventory.SetActive(false);
                isHidden = true;
            }
        }

        //drop items
        if (Input.GetKey("1"))
        {
            slots[0].GetComponent<Slot>().DropItem();
        }
        else if (Input.GetKey("2"))
        {
            slots[1].GetComponent<Slot>().DropItem();
        }
        if (Input.GetKey("3"))
        {
            slots[2].GetComponent<Slot>().DropItem();
        }
        if (Input.GetKey("4"))
        {
            slots[3].GetComponent<Slot>().DropItem();
        }
        if (Input.GetKey("5"))
        {
            slots[4].GetComponent<Slot>().DropItem();
        }
        
        //use items
        /*
        if (Input.GetKey("1"))
        {
            //use item   
            slots[0].GetComponent<Slot>().DropItem();
        }
        else if (Input.GetKey("2"))
        {
            //use item
            slots[1].GetComponent<Slot>().DropItem();
        }
        if (Input.GetKey("3"))
        {
            //use item
            slots[2].GetComponent<Slot>().DropItem();
        }
        if (Input.GetKey("4"))
        {
            //use item
            slots[3].GetComponent<Slot>().DropItem();
        }
        if (Input.GetKey("5"))
        {
            //use item
            slots[4].GetComponent<Slot>().DropItem();
        }*/
    }

	public void EquipWeapon(GameObject weapon){
		if(weapon == null){
			weaponSlot.GetComponent<WeaponSlot>().ConsumeItem();
		}
		else
		{
			Debug.Log("Equipped: " + weapon.name+ weapon.GetComponent<Pickup>().itemButton.name);
			
			Instantiate(weapon.GetComponent<Pickup>().itemButton, weaponSlot.transform, false);
		}
	}
	
	public void takeItem(GameObject item){
		for (int i = 0; i < slots.Length; i++)
        {
            if (!isFull[i])
            {
                Debug.Log("Player picked up "+item.name+".");
                isFull[i] = true;
				slots[i].GetComponent<Slot>().item = item.name;
                Instantiate(item.GetComponent<Pickup>().itemButton, slots[i].transform, false);
                //Destroy(gameObject);
                break;
            }
        }
	}
	
	public void putItem(GameObject item){
		for (int i = 0; i < slots.Length; i++)
        {
            if (isFull[i])
            {
				if(slots[i].GetComponent<Slot>().item == item.name){
					Debug.Log("Player dropped "+item.name+".");
					slots[i].GetComponent<Slot>().RemoveItem();
					//Instantiate(item.GetComponent<Pickup>().itemButton, slots[i].transform, false);
					//Destroy(gameObject);
					
					isFull[i] = false;
					break;
				}
            }
        }
	}
}
