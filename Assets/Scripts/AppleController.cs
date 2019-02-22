﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    public float healAmount = 20;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal()
    {
        PlayerHealth pH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
		pH.gainLife(healAmount);
		PlayerController pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        pc.HasEaten = true;
        pc.isPoisoned = false;

        Debug.Log("Player healed to: " + pc.health + "% hp");
        Destroy(gameObject);
    }
}
