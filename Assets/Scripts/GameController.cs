using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] objects;
    private const int INSECT = 0;
    private const int WOOD = 1;
    private const int BAKERY = 2;
    private const int APPLE = 3;
    private const int ALIEN = 4;
    private const int LAKE = 5;
    
    public DialogueController dialogueController;
    public PlayerController playerController; //Si comio manzana

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
        }

        if(Next)
        {
            if (!objects[INSECT].activeSelf)
            {
                Next = false;
                objects[INSECT].SetActive(true); //Appears enemy
                dialogueController.AlienAppearsDialogue();
            } else if (dialogueController.FirstTimeHit == 1)
            {
                Next = false;
                dialogueController.PlayerHits();
            } else if (dialogueController.IsAlienDead)
            {
                Next = false;
                dialogueController.AlienIsDeadDialogue();
                objects[APPLE].SetActive(true); //shows next mission
                objects[LAKE].SetActive(true); //shows next mission lake
          
            }
        }
    }
}
