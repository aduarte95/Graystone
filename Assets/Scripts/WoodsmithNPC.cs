using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodsmithNPC : NPCController
{
    const int RIGHT = 0; //Success on mission
    const int WRONG = 1;
    const int FAVOR_FOR_CHAIR = 2;
    const int CHAIR = 3;
    const int NO_JAM = 4;
    public GameObject candle;
	public GameObject chair;
    public HouseSceneController house;
    public bool AreDiamonds { get; protected set; } = false;
    public bool HasCandle { get; protected set; } = false;
    private bool HasChair { get; set; } = false; //To avoid entern in the loop when ask if has chair and if dialogue finishes chair
    private PlayerController pc;
    private CharacterController characterController;

    public override void talk()
    {
        if (gameController.Debugg)
        {
            HasChair = true;
            dialogueTrigger.TriggerDialogue(CHAIR);
            setPlayerVariables();
        }
        else
        {
             /*missionsGame.setFinished(CANDLE_MISSION); //FOR DEBUG
              gameController.objects[1].SetActive(true); //FOR DEBUG
              gameController.objects[5].SetActive(true); //FOR DEBUG*/

            if (!missionsGame.isFinished(BLUEBERRY_MISSION))
            {
                setPlayerVariables();
                if (missionsGame.isFinished(CANDLE_MISSION))
                {
                    if (!missionsGame.isFinished(BERRY_ALIEN_DEAD)) //First dialogue asking for favor
                    {
                        dialogueTrigger.TriggerDialogue(FAVOR_FOR_CHAIR);
                        missionsGame.setFinished(ASK_CHAIR_MISSION);
                    }
                    else
                    {
                        if (pc.GetComponent<InventoryController>().hasItem("Jar"))
                        {
                            chair.SetActive(true);
                            pc.GetComponent<InventoryController>().removeItem("Jar");
                            dialogueTrigger.TriggerDialogue(CHAIR);
                        }
                        else
                        {
                            dialogueTrigger.TriggerDialogue(NO_JAM);
                        }
                    }
                }
                else if (!missionsGame.isFinished(APPLE_MISSION)) //If the mission has not completed
                {
                    dialogueTrigger.TriggerDialogue(notInMission);
                }
                else if (missionsGame.isFinished(APPLE_MISSION) && GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>().hasNAmountOfItem("Apple", 5)) //NPC DEBUG quitar el true cuando player tenga el seteo de HASAPPLES 
                {
                    dialogueTrigger.TriggerDialogue(RIGHT);
                    pc.emptyInventory();
                    candle.SetActive(true);
                }
                else
                {
                    dialogueTrigger.TriggerDialogue(WRONG);
                }
            }
            else
            {
                dialogueTrigger.TriggerDialogue(notInMission);
            }
        }
    }

    public override void checkMission()
    {
        if (gameController.Debugg)
        {
            if (HasChair && dialogueTrigger.dialogues[CHAIR].Finished)
            {
                missionsGame.setFinished(BLUEBERRY_MISSION);
                HasChair = false;
                finishBerryMission(); //Comment if you don't want to be teletransported
            }
        }
        else
        {
            if (HasCandle && dialogueTrigger.dialogues[RIGHT].Finished)
            {
                finishCandleMission();
            }
            else if (dialogueTrigger.dialogues[FAVOR_FOR_CHAIR].Finished && !AreDiamonds)
            {
                AreDiamonds = true;
                dialogueTrigger.dialogues[FAVOR_FOR_CHAIR].setDiamondsMission();
            }
            else if (!HasChair && GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>().hasItem("Chair") && dialogueTrigger.dialogues[CHAIR].Finished)
            {
                finishBerryMission(); //TODO Implements if took chair then teletransport
            }
        }
    }

    void finishCandleMission()
    {
        HasCandle = false;
        missionsGame.setFinished(CANDLE_MISSION);
        gameController.CandleMissionFinished = true;
        gameController.Next = true;
        teletransportPlayer();
    }

    void finishBerryMission()
    {
        HasChair = true;
        missionsGame.setFinished(BLUEBERRY_MISSION);
        gameController.BlueberryMissionFinished = true;
        gameController.Next = true;
        dialogueTrigger.dialogues[]
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

    private void setPlayerVariables()
    {
        pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
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