using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollisionController : ObjectInteraction
{
    public DialogueTrigger dialogueTrigger;
    private const int NOJUG = 0;
    private const int JUGFULL = 1;
    override public void setText()
    {
        text = "Press Q button to take water";
        
    }
    
    override public void interact()
    {
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
        JugController jug = GameObject.Find("jug").GetComponent<JugController>();

        if (player.hasJug)
        {
            if (jug.isFull)
            {
                dialogueTrigger.TriggerDialogue(JUGFULL);
            }
            else
            {
                if (!jug.isFull)
                {
                    Debug.Log("Water Taken");
                    // TODO make things to see changes in jug in the game (using jug controller)
                    jug.isFull = true;
                }
            }


        }
        else
        {
            if (!player.hasJug)
            {
                dialogueTrigger.TriggerDialogue(NOJUG);
            }


        }


    }
}
