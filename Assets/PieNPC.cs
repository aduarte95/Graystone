using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieNPC : NPCController
{
    private const int ASK_FOR_OBJECTS = 0;
    private const int COMPLETE = 1;
    private bool firstTime = true;
    public bool HasWater { get; set; } = false;
    public bool HasBerries { get; set; } = false;
    public bool HasSugar { get; set; } = false;
    
    // Update is called once per frame
    void Update()
    {
        if (CanTalk) //actives in position of npc
        {
            CanTalk = false;
            transform.LookAt(targetPosition);

            if (missionsGame.isFinished(BLUEBERRY_MISSION)) //Mission 2 has finished
            {
                if (HasWater && HasBerries && HasSugar)
                {
                    dialogueTrigger.TriggerDialogue(COMPLETE);
                } else
                {
                    dialogueTrigger.TriggerDialogue(ASK_FOR_OBJECTS);
                }
            }
            else //If jumps the mission order
            {
                dialogueTrigger.TriggerDialogue(notInMission);
            }
        }

        if (dialogueTrigger.dialogues[ASK_FOR_OBJECTS].Finished && firstTime)
        {
            firstTime = false;
            dialogueTrigger.dialogues[ASK_FOR_OBJECTS].cleanDiamonds();
            dialogueTrigger.dialogues[ASK_FOR_OBJECTS].setDiamondsMission();
            dialogueTrigger.dialogues[COMPLETE].setDiamondsMission();
            dialogueTrigger.dialogues[notInMission].setDiamondsMission();
        }
    }

    public override void setName()
    {
        Name = "Tao Piepie";
    }
}