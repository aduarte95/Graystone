using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleNPC : NPCController
{
    public GameObject nextHouseDiamond;
    public GameObject[] myDiamonds;
    private int MoveSpeed = 4;
    private int MaxDist = 13;
    private int MinDist = 2;
    private int isWalkingHash = Animator.StringToHash("IsWalking");
    private int currentDialogue = 0;
    private bool StillMad { get; set; } = true; //Avoid npc seacrhes for player if eat another apple
    private bool firstTime = true;
    public Transform Sphere; //Set limits

    // Update is called once per frame
    void Update()
    {
        if(player.HasEaten) // DEBUG APPLE NPC quitar el false y poner ese cuando player ya tenga el seteo de la variable HasEaten
        {
           walk(); 
        } else if (CanTalk)
        {
            CanTalk = false;
            if(StillMad)
            {
                StillMad = false;
                dialogueTrigger.TriggerDialogue(currentDialogue);
                missionsGame.setFinished(APPLE_MISSION);
            }
             
        } else
        {
            if (dialogueTrigger.dialogues[currentDialogue].Finished && firstTime)
            {
                firstTime = false;
                dialogueTrigger.dialogues[currentDialogue].setDiamondsMission();
                //dialogueTrigger.dialogues[currentDialogue].cleanDiamonds(); // For first mission :o
                if (currentDialogue < dialogueTrigger.dialogues.Length - 1)
                {
                    ++currentDialogue;
                }
            }
        }

    }

    private void walk()
    {
        animator.SetBool("IsWalking", true);
        transform.LookAt(targetPosition);

        // DEBUG APPLE NPC
        if ((Vector3.Distance(transform.position, targetPosition.position) > MinDist) && (StillMad))
        {

            if ((Vector3.Distance(transform.position, Sphere.position) < MaxDist) || (Vector3.Distance(Sphere.position, targetPosition.position) < MaxDist))
            {
                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            }
            else
            {
                animator.SetBool(isWalkingHash, false);
                MoveSpeed = 0;
            }

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
       player.HasEaten = false; // DEBUG APPLE NPC. SAME jaja
       CanTalk = true;
    }

    public override void setName()
    {
        Name = "Steve Jobs";
    }
}
