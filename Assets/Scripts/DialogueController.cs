using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueTrigger[] objectsWithDialogues; //Array of objects that have dialog
    //public EnemyBehaviour alien; FOR GAME. Add to dialogue or will chrash
    public EnemyBehaviourProto alien; //PROTO
    private const int HOUSE = 0;
    private Dialogue currentDialog;
    public GameController gameController;
    private bool first = true; //See if it's alien first time dead
    public int FirstTimeHit { get; set; } = 0; // 0 means never hit at all, 1 means hit for the first time, 2 hit after the first time

    public bool IsAlienDead { get; set; } = false;//Alien have to change it if he dies. PROTO
    public bool FinishedHouse { get; set; } = false; //Allows to exit the house

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

    
    // Update is called once per frame
    void Update()
    {
        if (currentDialog != null)
        {
            if (currentDialog.Finished)
            {
                
                gameController.Next = true;
                currentDialog.Finished = false;

                if (currentDialog == objectsWithDialogues[HOUSE].dialogues[3]) 
                {
                    FinishedHouse = true; //If it's last dialogue allows to change scene
                }
            }
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

    }

    public void Begin() //First Dialogue
    {
        objectsWithDialogues[HOUSE].TriggerDialogue(0);
        currentDialog = objectsWithDialogues[HOUSE].dialogues[0];
    }

    public void AlienAppearsDialogue() 
    {
        objectsWithDialogues[HOUSE].TriggerDialogue(1);
        currentDialog = objectsWithDialogues[HOUSE].dialogues[1];
    }

    public void PlayerHits()
    {
        objectsWithDialogues[HOUSE].TriggerDialogue(2);
        currentDialog = objectsWithDialogues[HOUSE].dialogues[2];
    }

    public void AlienIsDeadDialogue()
    {
        if (IsAlienDead && first)
        {
            first = false;
            objectsWithDialogues[HOUSE].TriggerDialogue(3);
            currentDialog = objectsWithDialogues[HOUSE].dialogues[3];
        }
    }

    //PROTO
    public void setPlayerPoisoned(bool isPlayerPoisoned)
        {
            this.isPlayerPoisoned = isPlayerPoisoned;
        }
    }


