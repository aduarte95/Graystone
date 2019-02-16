using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueTrigger[] objectsWithDialogues; //Array of objects that have dialog
    public EnemyBehaviour alien;
    const int HOUSE = 0;

    bool isAlienDead = false;
    public bool IsAlienDead //Alien have to change it if he dies. PROTO
    {
        get
        {
            return isAlienDead;
        }
        set
        {
            isAlienDead = value;
        }
    }

    bool isPlayerPoisoned = false;
    public bool IsPlayerPoisoned
    {
        set
        {
            isPlayerPoisoned = value;
        }
    }

    bool isOnTheHouse = false; //House Scene says if player is on scene
    public bool IsOnTheHouse
    {
        set
        {
            isOnTheHouse = value;
        }
    }
    bool begin = true;
    bool first = true;

    // Update is called once per frame
    void Update()
    {
        if (begin)
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
        */
        if (isAlienDead && first)
        {
            first = false;
            objectsWithDialogues[HOUSE].TriggerDialogue(1);
        }
    }

    //PROTO
    public void setPlayerPoisoned(bool isPlayerPoisoned)
    {
        this.isPlayerPoisoned = isPlayerPoisoned;
    }
}
