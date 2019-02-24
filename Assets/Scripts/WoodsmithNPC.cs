using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodsmithNPC : NPCController
{
    const int RIGHT = 0; //Success on mission
    const int WRONG = 1;
    public GameObject candle;
    public HouseSceneController house;
    private bool playerTransported = false;
    private PlayerController pc;
    private CharacterController characterController;

    // Update is called once per frame
    void Update()
    {
        if(CanTalk) //actives in position of npc
        {
            CanTalk = false;
            if(true) //NPC DEBUG quitar el true cuando player tenga el seteo de HASAPPLES 
            {

                dialogueTrigger.TriggerDialogue(RIGHT);
                pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
                pc.emptyInventory();
                candle.SetActive(true);
                
            } else
            {
                dialogueTrigger.TriggerDialogue(WRONG);
            }
        }

        if (!playerTransported && dialogueTrigger.dialogues[RIGHT].Finished)
        {
            playerTransported = true;
            characterController.enabled = false;
            pc.gameObject.transform.position = house.scenePosition;
            characterController.enabled = true;
            house.setObjects();
        }

    }

    public override void setName()
    {
        Name = "Woody Carpenter";
    }
}
