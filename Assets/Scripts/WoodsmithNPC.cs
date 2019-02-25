using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodsmithNPC : NPCController
{
    const int RIGHT = 0; //Success on mission
    const int WRONG = 1;
    const int FAVOR_FOR_CHAIR = 2;
    const int CHAIR = 3;
    public GameObject candle;
    public HouseSceneController house;
    public bool HasCandle { get; protected set; } = false;
    private bool playerTransported = false;
    private PlayerController pc;
    private CharacterController characterController;
    private bool debug = true;
   
    // Update is called once per frameaw
    void Update()
    {
        if(CanTalk) //actives in position of npc
        {
            CanTalk = false;
            transform.LookAt(targetPosition);
           /* missionsGame.setFinished(CANDLE_MISSION); //FOR DEBUG
            gameController.objects[1].SetActive(true); //FOR DEBUG
            gameController.objects[5].SetActive(true); //FOR DEBUG*/

            if (missionsGame.isFinished(CANDLE_MISSION))
            {
                if (!missionsGame.isFinished(BLUEBERRY_MISSION)) //First dialogue asking for favor
                {
                    dialogueTrigger.TriggerDialogue(FAVOR_FOR_CHAIR);
                    missionsGame.setFinished(ASK_CHAIR_MISSION);
                }
                else
                {
                    dialogueTrigger.TriggerDialogue(CHAIR);
                }
            } else if (!missionsGame.isFinished(APPLE_MISSION)) //If the mission has not completed
            {
                dialogueTrigger.TriggerDialogue(notInMission);
            }
            else if (missionsGame.isFinished(APPLE_MISSION) && true) //NPC DEBUG quitar el true cuando player tenga el seteo de HASAPPLES 
            {
                debug = false;
                dialogueTrigger.TriggerDialogue(RIGHT);
                pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
                pc.emptyInventory();
                candle.SetActive(true);
            }
            else
            {
                dialogueTrigger.TriggerDialogue(WRONG);
            }
        }

        if (HasCandle && dialogueTrigger.dialogues[RIGHT].Finished)
        {
            finishCandleMission();  
        } else if (dialogueTrigger.dialogues[FAVOR_FOR_CHAIR].Finished)
        {
            dialogueTrigger.dialogues[FAVOR_FOR_CHAIR].setDiamondsMission();
        }
    }

    void finishCandleMission()
    {
        HasCandle = false;
        missionsGame.setFinished(CANDLE_MISSION);
        gameController.CandleMissionFinished = true;
        gameController.Next = true;
        //TODO: MAYBE CAN BE A METHOD ON PLAYERCONTROLLER
        characterController.enabled = false;
        pc.gameObject.transform.position = house.scenePosition;
        characterController.enabled = true;
        house.setObjects();
        positionController.cleanText();
    }

    public override void setName()
    {
        Name = "Woody Carpenter";
    }

    public override void setHasObject(int theObject)
    {
        if (theObject == 0)
        {
            HasCandle = true;
        }
    }
}
