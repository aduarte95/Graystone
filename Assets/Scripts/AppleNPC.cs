using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleNPC : NPCController
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanWalk())
        {
            walk();
        } else if (canTalk)
        {
            Debug.Log("Que");
            canTalk = false;
            dialogueTrigger.TriggerDialogue(0);
        }
        
    }

    override public bool CanWalk()
    {
        return false; // DEBUG APPLE NPC player.HasEaten;
    }
    override public void stopWalk()
    {
        // DEBUG APPLE NPC player.HasEaten = false;
        canTalk = true;
    }
}
