using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject insect;
    public DialogueController dialogueController;

    public bool Begin { get; private set; } = true;
    public bool Next { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Begin)
        {
            dialogueController.Begin();
            Begin = false;
            //insect.SetActive(true);
        }

        if(Next)
        {
            if (!insect.activeSelf)
            {
                Next = false;
                insect.SetActive(true); //Appears enemy
                dialogueController.AlienAppearsDialogue();
            }
            
            if(dialogueController.IsAlienDead)
            {
                Next = false;
                dialogueController.AlienIsDeadDialogue();
            }
        }
    }
}
