using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueTrigger[] objectsWithDialogues; //Array of objects that have dialog
    const int HOUSE = 0;
    const int ALIEN = 1;
    bool isAlienDead = false;

    // Start is called before the first frame update
    void Start()
    {
        objectsWithDialogues[HOUSE].TriggerDialogue(0); 
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlienDead)
        {
            isAlienDead = false; //Just once
            objectsWithDialogues[HOUSE].TriggerDialogue(1);
        }
    }

    //Alien have to change it if he dies.
    public void setAlienDeadd(bool isAlienDead)
    {
        this.isAlienDead = isAlienDead;
    }
}
