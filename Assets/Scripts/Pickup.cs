﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private const int CANDLE = 0;
    private InventoryController inventory;
    private NPCController npc;
    private string npcName;
    public GameObject itemButton;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>();  

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (!inventory.isFull[i])
                {
                    Debug.Log("Player picked up an item.");
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
					inventory.slots[i].GetComponent<Slot>().item = gameObject.tag;

                    if(gameObject.GetComponent<Candle>() != null)
                    {
                        npc = GameObject.FindGameObjectWithTag("Woodsmith").GetComponent<NPCController>();
                        npc.setHasObject(CANDLE);
                    }

                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

}
