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
        PlayerController pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        pc.health += 20;
        if (pc.health > 100)
        {
            pc.health = 100;
        }
        Debug.Log("Player healed to: " + pc.health + "% hp");
        Destroy(gameObject);
    }
}
