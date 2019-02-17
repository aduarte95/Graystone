using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleNPC : NPCController
{
    public Transform targetPosition;
    private int MoveSpeed = 4;
    private int MaxDist = 10;
    private int MinDist = 2;
    private int isWalkingHash = Animator.StringToHash("IsWalking");
   
    

    // Update is called once per frame
    void Update()
    {
        if(false) //player.HasEaten) // DEBUG APPLE NPC
        {
            walk();
        } else if (CanTalk)
        {
            CanTalk = false;
            dialogueTrigger.TriggerDialogue(0);
        }
        
    }

    private void walk()
    {
        animator.SetBool("IsWalking", true);
        transform.LookAt(targetPosition);

        // DEBUG APPLE NPC
        if (Vector3.Distance(transform.position, targetPosition.position) > MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        }
        else
        {
            animator.SetBool(isWalkingHash, false);
            MoveSpeed = 0;
            setCanTalk();
        }
    }

    private void setCanTalk()
    {
       // player.HasEaten = false; // DEBUG APPLE NPC
        CanTalk = true;
    }

    public override void setName()
    {
        Name = "Steve Jobs";
    }
}
