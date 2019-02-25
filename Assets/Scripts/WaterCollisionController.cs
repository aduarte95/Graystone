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
        InventoryController inventory = GameObject.Find("Player").GetComponent<InventoryController>();
        JugController jug = GameObject.Find("Jug").GetComponent<JugController>();

        if (inventory.hasItem("Jug"))
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
            if (!inventory.hasItem("Jug"))
            {
                dialogueTrigger.TriggerDialogue(NOJUG);
            }


        }


    }
}
