using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodsmithNPC : NPCController
{
    const int RIGTH = 0; //Success on mission
    const int WRONG = 1;

    // Update is called once per frame
    void Update()
    {
        if(CanTalk) //actives in position of npc
        {
            CanTalk = false;
            if(true)//player.HasApples) NPC DEBUG 
            {

                dialogueTrigger.TriggerDialogue(RIGTH);
            } else
            {
                dialogueTrigger.TriggerDialogue(WRONG);
            }
        }
    }

    public override void setName()
    {
        Name = "Abeto Carpenter";
    }
}
