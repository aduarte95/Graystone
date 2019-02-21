using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Animator animator;
    private AudioSource audioSource;
    public AudioClip hit;
    public AudioClip stickBow;
    public int isWalkingHash = Animator.StringToHash("IsWalking");
    public int canRun = Animator.StringToHash("CanRun");
    public float health;
    public float speed;
    public float acceleration;
    public float maxSpeed;
    public float rotationSpeed = 75.0f;
    public InventoryController inventory;
    public string weaponEquipped = "";
    // Start is called before the first frame update
    public bool ableToMove = true;
    public bool onTheHouse = false;
    public bool isInLake = true;
    public int attack = Animator.StringToHash("Hit");
    public DialogueController dialogueController;
    public bool isPoisoned = false;
    public PlayerHealth healthBar;
    

    public EnemyBehaviourProto enemy;
    public Transform Enemy; // to use the transform.position of enemy after Attack

    public DialogueManager dialogueManager;
    //DEBUG APPLE NPC 
    public bool HasEaten = false;

    //
    public bool HasApples  = true; // DEBUG WOODSMITH NPC

    void Start()
    {
        health = 100f;
        speed = 2.0f;
        setGraystoneVariables();
        Debug.Log(gameObject.name);
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        animator.SetBool(canRun, true);
        inventory = gameObject.GetComponent<InventoryController>();
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


        if ((!Front() || ableToMove || !Input.GetKey("w") || !(Input.GetKey("w") && (Input.GetKey("a") || Input.GetKey("d"))))&& (dialogueManager.isActive == false))
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            RaycastHit res;
            if (!GetComponent<Rigidbody>().SweepTest(transform.forward, out res, speed * Time.deltaTime + 0.01f))
            {
                if (!Front())
                {
                    transform.Translate(0, 0, translation);

                }
            }

            transform.Rotate(0, rotation, 0);

           

            if (translation != 0)
            {
                animator.SetBool(isWalkingHash, true);
                if (speed < maxSpeed)
                {
                    speed += acceleration * Time.deltaTime;
                }

                if (isPoisoned)
                {
                    healthBar.dealDamage(0.05f);    
                }
                
            }
            else
            {
                speed = 2.0f;
                animator.SetBool(isWalkingHash, false);
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
                        audioSource.Play();
                        audioSource.PlayOneShot(stickBow);

                        if (dialogueController.FirstTimeHit == 1)
                        {
                            setFirstHit(2);
                        }
                    }


                    StartCoroutine(Attack());

                    Debug.Log("Pegó");
                }
                
            }
        }
        else
        {
            animator.SetBool(isWalkingHash, false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

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


    void OnTriggerEnter(Collider collision)
    {
        speed = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey("w") && (other.GetComponent<Collider>().gameObject.name != "Terrain") && (other.tag != "Enemy"))
        {
            speed = 0;
            ableToMove = false;
            animator.SetBool(isWalkingHash, false);
        }
    }


    private void OnTriggerExit(Collider col)
    {
        animator.SetBool(isWalkingHash, true);
        ableToMove = true;
    }

    IEnumerator Attack()
    {

        //animator.SetBool(attack, true);
        animator.SetTrigger("Hit");

        if ((Vector3.Distance(transform.position, Enemy.position) >= 0) &&
            (Vector3.Distance(transform.position, Enemy.position) <= 2))
        {
            if (enemy.gameObject.activeSelf)
            {
                enemy.getHit(10);
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
