using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueTrigger[] objectsWithDialogues; //Array of objects that have dialog
    const int HOUSE = 0;
    bool isAlienDead = false;
    bool isPlayerPoisoned = false;
    bool isOnTheHouse = false; //House Scene says if player is on scene
    bool begin = true;

    // Update is called once per frame
    void Update()
    {
        if(begin)
        {
            objectsWithDialogues[HOUSE].TriggerDialogue(0);
            begin = false;
        }

       /* if (isOnTheHouse)
        {
            objectsWithDialogues[HOUSE].TriggerDialogue(1);
            isOnTheHouse = false;
        }

        if (isPlayerPoisoned)
        {
            isPlayerPoisoned = false; //Just once
            objectsWithDialogues[HOUSE].TriggerDialogue(2);
        }

        if (isAlienDead)
        {
            isAlienDead = false; //Just once
            objectsWithDialogues[HOUSE].TriggerDialogue(3);
        }*/
    }

    public void setIsOnTheHouse()
    {
        isOnTheHouse = true;
    }

    //Alien have to change it if he dies. PROTO
    public void setAlienDead(bool isAlienDead)
    {
        this.isAlienDead = isAlienDead;
    }

    //PROTO
    public bool getAlienDead()
    {
        return true;
    }

    //PROTO
    public void setPlayerPoisoned(bool isPlayerPoisoned)
    {
        this.isPlayerPoisoned = isPlayerPoisoned;
    }
}
