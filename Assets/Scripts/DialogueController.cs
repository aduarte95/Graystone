using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public Queue<DialogueTrigger> objectsWithDialogues; //Array of objects that have dialog
    DialogueTrigger houseDialog;
    bool isAlienDead = false;

    // Start is called before the first frame update
    void Start()
    {
        house = objectsWithDialogues.Dequeue();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlienDead)
        {
            isAlienDead = false; //Just once


        }
    }

    void dequeueDialog()
    {
        objectsWithDialogues.Dequeue().TriggerDialogue();
    }

    //Alien have to change it if he dies.
    public void setAlienDeadd(bool isAlienDead)
    {
        this.isAlienDead = isAlienDead;
    }
}
