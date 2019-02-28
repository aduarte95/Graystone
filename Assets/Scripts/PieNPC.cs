using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieNPC : NPCController
{
    private const int ASK_FOR_OBJECTS = 0;
    private const int COMPLETE = 1;
    private bool firstTime = true;
    public PlayerController pc;
    public CharacterController characterController;
    public HouseSceneController house;
    public bool HasWater { get; set; } = false;
    public bool HasBerries { get; set; } = false;
    public bool HasSugar { get; set; } = false;
    public bool HasBed { get; set; } = false;
    
    public override void talk()
    {
        if (missionsGame.isFinished(BLUEBERRY_MISSION)) //Mission 2 has finished
        {
            if (GameObject.FindGameObjectWithTag("Jug").GetComponent<JugController>().isFull && GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>().hasNAmountOfItem("Berry", 3) && GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>().hasItem("Sugar"))
            {
				GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>().takeItem("Sugar");
                dialogueTrigger.TriggerDialogue(COMPLETE);			
            }
            else
            {
                dialogueTrigger.TriggerDialogue(ASK_FOR_OBJECTS);
                missionsGame.setFinished(ASK_BED_MISSION);
            }
        }
        else //If jumps the mission order
        {
            dialogueTrigger.TriggerDialogue(notInMission);
        }
    }

    public override void checkMission()
    {
        if (dialogueTrigger.dialogues[ASK_FOR_OBJECTS].Finished && firstTime)
        {
            firstTime = false;
            dialogueTrigger.dialogues[ASK_FOR_OBJECTS].cleanDiamonds();
            dialogueTrigger.dialogues[ASK_FOR_OBJECTS].setDiamondsMission();
            dialogueTrigger.dialogues[COMPLETE].setDiamondsMission();
            dialogueTrigger.dialogues[notInMission].setDiamondsMission();
        }
        else if (dialogueTrigger.dialogues[COMPLETE].Finished && HasBed)
        {
            finishMission();
        }
        else if (!dialogueTrigger.dialogues[COMPLETE].Finished)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>().hasNAmountOfItem("Berry", 3))
            {
                dialogueTrigger.dialogues[COMPLETE].cleanDiamonds(); //Has the berries diamond
                Debug.Log("clean berry");
            }
            if (GameObject.FindGameObjectWithTag("Jug").GetComponent<JugController>().isFull)
            {
                GameObject.Find("River's Diamond").SetActive(false);
            }
        }
    }

    public void finishMission()
    {
        HasBed = false;
        gameController.PieMissionFinished = true;
        gameController.Next = true;
        teletransportPlayer();
    }

    void teletransportPlayer()
    {
        characterController.enabled = false;
        pc.gameObject.transform.position = house.scenePosition;
        characterController.enabled = true;
        house.setObjects();
        positionController.cleanText();
    }

    public override void setName()
    {
        Name = "Tao Piepie";
    }
}