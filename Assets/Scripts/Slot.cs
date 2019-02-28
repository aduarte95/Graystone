using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private InventoryController inventory;
    public string item;
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }   
    }

    public void DropItem()
    {
        if (inventory.isFull[i])
        {
            Debug.Log("Player drops item.");
            foreach (Transform child in transform)
            {
                child.GetComponent<Spawn>().SpawnDroppedItem();
                GameObject.Destroy(child.gameObject);
            }
			item = "";
        }
    }

    public void ConsumeItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Spawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
		item = "";
    }
	
	public void RemoveItem(){
		if (inventory.isFull[i])
        {
            Debug.Log("Removing item.");
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
			item = "";
        }
	}
	
	public void Heal()
    {
        PlayerHealth pH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        PoisonLevel pL = GameObject.FindGameObjectWithTag("Player").GetComponent<PoisonLevel>();
		pH.gainLife(20);
        pL.losePoison(1);
		PlayerController pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        pc.HasEaten = true;
        pc.isPoisoned = false;
		RemoveItem();
    }
	
	public void Damage()
    {
        PlayerHealth pH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
		pH.dealDamage(100);
		RemoveItem();
    }
	
	public void Poison()
    {
		PlayerController pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        PlayerHealth pH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        PoisonLevel pL = GameObject.FindGameObjectWithTag("Player").GetComponent<PoisonLevel>();
		pH.dealDamage(10);
        pL.getPoison(3);
        pc.isPoisoned = true;
		RemoveItem();
    }
}
