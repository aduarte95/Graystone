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
    public bool HasCandle { get; protected set; } = false;
    private bool HasChair { get; set; } = false; //TODO Implementar que tenga silla para volver a casa 
    private bool playerTransported = false;
    private PlayerController pc;
    private CharacterController characterController;
    private bool debug = false;
    private bool HasJam { get; set; } = true; //TODO Implementar que tenga jam
    // Update is called once per frameaw

    void Update()
    {
        if (debug)
        {
            if (CanTalk) //actives in position of npc
            {
                CanTalk = false;
                HasChair = true;
                dialogueTrigger.TriggerDialogue(CHAIR);
                setPlayerVariables();
            }
                if (HasChair && dialogueTrigger.dialogues[CHAIR].Finished)
            {
                finishBerryMission(); //TODO Implements if took chair then teletransport
            }
        }
        else
        {
            if (CanTalk) //actives in position of npc
            {
                CanTalk = false;
                transform.LookAt(targetPosition);
                /* missionsGame.setFinished(CANDLE_MISSION); //FOR DEBUG
                  gameController.objects[1].SetActive(true); //FOR DEBUG
                  gameController.objects[5].SetActive(true); //FOR DEBUG*/

                if (missionsGame.isFinished(CANDLE_MISSION))
                {
                    if (!missionsGame.isFinished(BERRY_ALIEN_DEAD)) //First dialogue asking for favor
                    {
                        dialogueTrigger.TriggerDialogue(FAVOR_FOR_CHAIR);
                        missionsGame.setFinished(ASK_CHAIR_MISSION);
                    }
                    else
                    {
                        if (HasJam)
                        {
                            dialogueTrigger.TriggerDialogue(CHAIR);
                            setPlayerVariables();
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
                else if (missionsGame.isFinished(APPLE_MISSION) && true) //NPC DEBUG quitar el true cuando player tenga el seteo de HASAPPLES 
                {
                    debug = false;
                    dialogueTrigger.TriggerDialogue(RIGHT);
                    setPlayerVariables();
                    pc.emptyInventory();
                    candle.SetActive(true);
                }
                else
                {
                    dialogueTrigger.TriggerDialogue(WRONG);
                }
            }
        }

        if (!debug)
        {
            if (HasCandle && dialogueTrigger.dialogues[RIGHT].Finished)
            {
                finishCandleMission();
            }
            else if (dialogueTrigger.dialogues[FAVOR_FOR_CHAIR].Finished)
            {
                dialogueTrigger.dialogues[FAVOR_FOR_CHAIR].setDiamondsMission();
            }
            else if (HasChair && dialogueTrigger.dialogues[CHAIR].Finished)
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
        //TODO: MAYBE CAN BE A METHOD ON PLAYERCONTROLLER
        teletransportPlayer();
    }

    void finishBerryMission()
    {
		chair.SetActive(true);
        HasChair = false;
        missionsGame.setFinished(BLUEBERRY_MISSION);
        gameController.BlueberryMissionFinished = true;
        gameController.Next = true;
        //TODO: MAYBE CAN BE A METHOD ON PLAYERCONTROLLER
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
