using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private AudioSource audioSource;
    public AudioClip hit;
    public AudioClip stickBow;
    public int isWalkingHash = Animator.StringToHash("IsWalking");
    public int canRun = Animator.StringToHash("CanRun");
    public int activeDialogue = Animator.StringToHash("activeDialogue");
    public float health;
    public float speed;
    public float acceleration;
    public float maxSpeed;
    public float rotationSpeed = 75.0f;
    public InventoryController inventory;
    public string weaponEquipped = "";
    // Start is called before the first frame update
    public bool onTheHouse;
    public bool isInLake = true;
    public int attack = Animator.StringToHash("Hit");
    public DialogueController dialogueController;
    public bool isPoisoned = false;
    public PlayerHealth healthBar;
    public bool hasJug = false; // to control if player has jug equiped
    
    

    public EnemyBehaviourProto enemy;
    public Transform Enemy; // to use the transform.position of enemy after Attack

    public EnemyBehaviour enemyBerry;
    public Transform EnemyBerry; // to use the transform.position of enemy after Attack

    public WormBehaviour wormG1;
    public Transform WormG1;

    public WormBehaviour wormG2;
    public Transform WormG2;

    public WormBehaviour wormG3;
    public Transform WormG3;

    public WormBehaviour wormB1;
    public Transform WormB1;

    public WormBehaviour wormB2;
    public Transform WormB2;

    public WormBehaviour wormB3;
    public Transform WormB3;

    public DialogueManager dialogueManager;
    //DEBUG APPLE NPC 
    public bool HasEaten = false;

    //
    public bool HasApples  = true; // DEBUG WOODSMITH NPC

    
    
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;
    
    public Vector3 dontMove = new Vector3(0,0,0);

    
    
    void Start()
    {
        health = 100f;
        speed = 2.0f;
        onTheHouse = true;
        Debug.Log(gameObject.name);
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animator.SetBool(canRun, true);
        inventory = gameObject.GetComponent<InventoryController>();
        controller = GetComponent<CharacterController>();
    }

    public void setOnTheHouse(bool isOnTheHouse)
    {
        onTheHouse = isOnTheHouse;
    }

    public void setInLake(bool isInLake)
    {
        this.isInLake = isInLake;
    }

    public void setHouseVariables()
    {
        acceleration = 1.0f;
        maxSpeed = 5.0f;
    }

    public void setGraystoneVariables()
    {
        acceleration = 5.0f;
        maxSpeed = 10.0f;
        onTheHouse = false;
    }

    public void setFirstHit(int fisrtTimeHit)
    {
        dialogueController.FirstTimeHit = fisrtTimeHit;
    }




    // Update is called once per frame
    void Update()
    {
        /*if (isPoisoned)
        {
            StartCoroutine(poisoned());
        }*/

        if (onTheHouse)
        {
            setHouseVariables();
            animator.SetBool(canRun, false);
        }
        else
        {
            setGraystoneVariables();
            animator.SetBool(canRun, true);
        }

        if (inventory.inventoryLength >= inventory.slots.Length)
        {
            HasApples = true;
        }
        else if (inventory.inventoryLength < inventory.slots.Length)
        {
           
            HasApples = true;
        }

        if (dialogueManager.isActive == false)
        {
            //animator.SetBool(activeDialogue, false);
            controller.enabled = true;

            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            RaycastHit res;

            //transform.Translate(0, 0, translation);

            //transform.Rotate(0, rotation, 0);
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            //moveDirection = transform.TransformDirection(moveDirection);
            //moveDirection = moveDirection * speed;
            // Move the controller
            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveDirection);
            }

            controller.Move(moveDirection / 20);

            if (translation != 0 || moveDirection != Vector3.zero)
            {
                animator.SetBool(isWalkingHash, true);
                if (speed < maxSpeed)
                {
                    speed += acceleration * Time.deltaTime;
                }

                if (isPoisoned)
                {
                    healthBar.dealDamage(gameObject.GetComponent<PoisonLevel>().currentPoison/80);
                }

            }
            else
            {
                
                speed = 2.0f;
                animator.SetBool(isWalkingHash, false);
            }
        }
        else if (dialogueManager.isActive)
        {
            animator.SetBool(isWalkingHash, false);
            //animator.SetBool(activeDialogue, true);
            controller.enabled = false;
        }



        //SETEAR EN TRUE QUE SE COMIO LAS MANZANAS. MIENTRAS TANTO JAJA
            /*if (Input.GetKeyDown(KeyCode.R))
            {
                HasEaten = true;
            }*/

            if (Input.GetKeyDown(KeyCode.P))
            {
                // DEBUG APPLE NPC 

                // HasApples = true; // DEBUG APPLE NPC 
                if (dialogueManager.isActive == false)
                {
                    if (dialogueController.FirstTimeHit == 0)
                    {
                        audioSource.PlayOneShot(hit);

                        setFirstHit(1);
                    }
                    else
                    {
                        //audioSource.Play();
                        audioSource.PlayOneShot(stickBow);

                        if (dialogueController.FirstTimeHit == 1)
                        {
                            setFirstHit(2);
                        }
                    }
                    StartCoroutine(Attack());
                }
                
            }
    }

    public bool Front()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.0f, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Attack()
    {

        //animator.SetBool(attack, true);
        animator.SetTrigger("Hit");

        if ((Vector3.Distance(transform.position, Enemy.position) >= 0) &&
            (Vector3.Distance(transform.position, Enemy.position) <= 2))
        {
            if (enemy.gameObject.activeSelf && inventory.hasWeapon()
            )
            {
                StartCoroutine(enemy.dealDamage(10));
            }
        }

        if ((Vector3.Distance(transform.position, EnemyBerry.position) >= 0) &&
            (Vector3.Distance(transform.position, EnemyBerry.position) <= 2))
        {
            if (enemyBerry.gameObject.activeSelf)
            {
                enemyBerry.getHit(10);
            }
        }

        if ((Vector3.Distance(transform.position, WormG1.position) >= 0) &&
            (Vector3.Distance(transform.position, WormG1.position) <= 2))
        {
            if (wormG1.gameObject.activeSelf)
            {
                wormG1.getHit(10);
            }
        }

        if ((Vector3.Distance(transform.position, WormG2.position) >= 0) &&
            (Vector3.Distance(transform.position, WormG2.position) <= 2))
        {
            if (wormG2.gameObject.activeSelf)
            {
                wormG2.getHit(10);
            }
        }

        if ((Vector3.Distance(transform.position, WormG3.position) >= 0) &&
            (Vector3.Distance(transform.position, WormG3.position) <= 2))
        {
            if (wormG3.gameObject.activeSelf)
            {
                wormG3.getHit(10);
            }
        }

        if ((Vector3.Distance(transform.position, WormB1.position) >= 0) &&
            (Vector3.Distance(transform.position, WormB1.position) <= 2))
        {
            if (wormB1.gameObject.activeSelf)
            {
                wormB1.getHit(10);
            }
        }

        if ((Vector3.Distance(transform.position, WormB2.position) >= 0) &&
            (Vector3.Distance(transform.position, WormB2.position) <= 2))
        {
            if (wormB2.gameObject.activeSelf)
            {
                wormB2.getHit(10);
            }
        }

        if ((Vector3.Distance(transform.position, WormB3.position) >= 0) &&
            (Vector3.Distance(transform.position, WormB3.position) <= 2))
        {
            if (wormB3.gameObject.activeSelf)
            {
                wormB3.getHit(10);
            }
        }

        yield return new WaitForSeconds(0.5f);
        animator.SetBool(attack, false);
    }

    /*IEnumerator poisoned()
    {
        while (true)
        {
            healthBar.dealDamage(3);
            yield return new WaitForSeconds(1000);
                
        }
    }*/

    public void emptyInventory()
    {
        inventory.empty();
    }


}
