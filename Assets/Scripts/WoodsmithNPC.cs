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
        if(CanTalk) //ACTIVAR ESTO CON UN BOTÓN EN PLAYER
        {
            CanTalk = false;
            if(player.HasApples)
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
