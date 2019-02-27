﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryNPC : NPCController
{
	public GameObject jam;
    private const int KILL_ALIEN = 0;
    private const int JAM = 1;

    public bool is_berry_alien_dead = false;

    public override void talk()
    {
        if (missionsGame.isFinished(ASK_CHAIR_MISSION)) //Woodsmith already ask for the favor
        {
            if (missionsGame.isFinished(BERRY_ALIEN_DEAD))
            {
                dialogueTrigger.TriggerDialogue(JAM);
                jam.SetActive(true);
            }
            else
            {
                dialogueTrigger.TriggerDialogue(KILL_ALIEN);
            }
        }
        else //If jumps the mission order
        {
            dialogueTrigger.TriggerDialogue(notInMission);
        }
    }

    public override void checkMission()
    {
        if (dialogueTrigger.dialogues[KILL_ALIEN].Finished && !is_berry_alien_dead)
        {
            dialogueTrigger.dialogues[KILL_ALIEN].setDiamondsMission();
        }
        else if (is_berry_alien_dead)
        {
            missionsGame.setFinished(BERRY_ALIEN_DEAD);
            dialogueTrigger.dialogues[KILL_ALIEN].cleanDiamonds();
        }
    }

    public override void setName()
    {
        Name = "Joe Berry";
    }
}
