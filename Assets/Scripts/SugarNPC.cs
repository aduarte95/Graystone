using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarNPC : NPCController
{
    private const int KILL_ALIENS = 0;
    private const int COMPLETE = 1;
    private const int HAVE_OBJECTS = 2;
    private bool HasSugar { get; set; } = false;
    public GameObject sugar;
    public int AliensAreDead { get; set; } = 0;


    private bool firstTime = true;
    
    public bool HasBerries { get; set; } = false;

    public override void talk()
    {
        if(missionsGame.isFinished(ASK_BED_MISSION)) //If already talked with baker 
        {
            if (AliensAreDead < 6) //Aliens are not dead
            {
                dialogueTrigger.TriggerDialogue(KILL_ALIENS); //Ask for kill aliens
            } else
            {
                if (firstTime)
                {
                    dialogueTrigger.TriggerDialogue(COMPLETE); //Gives sugar
                                                               //TODO: ALL SUGAR INTERACTION
                    dialogueTrigger.dialogues[COMPLETE].cleanDiamonds(); //Removes diamond from mission
                    sugar.SetActive(true);
                } else
                {
                    dialogueTrigger.TriggerDialogue(HAVE_OBJECTS); //Have objects so can't take more.
                }
            }
        } else //not in turn >:(
        {
            dialogueTrigger.TriggerDialogue(notInMission);
        }
    }

    public override void checkMission()
    {
    }

    public override void setName()
    {
        Name = "Sugar Daddy";
    }
}