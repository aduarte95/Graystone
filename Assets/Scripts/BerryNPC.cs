using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryNPC : NPCController
{
    private const int KILL_ALIEN = 0;
    private const int JAM = 1;
    // Update is called once per frame
    void Update()
    {
        if (CanTalk) //actives in position of npc
        {
            CanTalk = false;
            transform.LookAt(targetPosition);

            if (missionsGame.isFinished(ASK_CHAIR_MISSION)) //Woodsmith already ask for the favor
            {
                dialogueTrigger.TriggerDialogue(KILL_ALIEN);

            }
            else if (missionsGame.isFinished(BERRY_ALIEN_DEAD))
            {
                dialogueTrigger.TriggerDialogue(JAM);
            }
            else //If jumps the mission order
            {
                dialogueTrigger.TriggerDialogue(notInMission);
            }
        }

        if (dialogueTrigger.dialogues[KILL_ALIEN].Finished)
        {
            dialogueTrigger.dialogues[KILL_ALIEN].setDiamondsMission();
        }
    }

    public override void setName()
    {
        Name = "Joe Berry";
    }
}
