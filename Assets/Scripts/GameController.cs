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
    
    public int alienDied = 0; // i'll look for a better solution, but this will be needed for the best behavior of the dialogue that makes alien appears

    
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

        //DESCOMENTAR PARA INICIAR MISION . TODOS LOS DIALOGOS ESTAN EN HOUSE CAMERA
        /*
        
        if (Begin) //Dialogo inicial
       {
           dialogueController.Begin();
           Begin = false;
       }


         if(Next) //Si el dialogo termino permite a los otros dialogos entrar
       {
           if (!(objects[INSECT].activeSelf) && (alienDied == 0)) //Aparece el alien y muestra dialogos
           {
               Next = false;
               objects[INSECT].SetActive(true); //Appears enemy
               dialogueController.AlienAppearsDialogue();
           } else if (dialogueController.FirstTimeHit == 1) //si dio primer golpe aparece dialogo que debe tomar palo. TODO: hacer que el palo apareza, tal vez agregando un objeto palo acá y desactivando desde el inicio
           {
               Next = false;
               dialogueController.PlayerHits();
               dialogueController.FirstTimeHit = 2;
           } else if (dialogueController.IsAlienDead) //Dialogo donde el alien muere y ya le permite salir de la casa. EL ALIEN DEBE AVISARLE A DIALOGUE CONTROLLER QUE MURIO. AHORITA LO HACE CON M JAJA
           {
               Next = false;
               dialogueController.AlienIsDeadDialogue();
               alienDied = 1;
               objects[APPLE].SetActive(true); //shows next mission
               objects[LAKE].SetActive(true); //shows next mission lake
           }
       }
       */
    }
}
