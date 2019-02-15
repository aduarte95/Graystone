using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueTrigger[] objectsWithDialogues; //Array of objects that have dialog
    const int HOUSE = 0;
    bool isAlienDead = false;
    bool isPlayerPoisoned = false;

    // Start is called before the first frame update
    void Start()
    {
        objectsWithDialogues[HOUSE].TriggerDialogue(0); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerPoisoned)
        {
            isPlayerPoisoned = false; //Just once
            objectsWithDialogues[HOUSE].TriggerDialogue(1);
        }

        if (isAlienDead)
        {
            isAlienDead = false; //Just once
            objectsWithDialogues[HOUSE].TriggerDialogue(2);
        }
    }

    //Alien have to change it if he dies.
    public void setAlienDead(bool isAlienDead)
    {
        this.isAlienDead = isAlienDead;
    }

    public void setPlayerPoisoned(bool isPlayerPoisoned)
    {
        this.isPlayerPoisoned = isPlayerPoisoned;
    }
}
