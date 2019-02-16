﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Animator animator;
    public int isWalkingHash = Animator.StringToHash("IsWalking");
    public int canRun = Animator.StringToHash("CanRun");
    public float speed;
    public float acceleration;
    public float maxSpeed;
    public float rotationSpeed = 75.0f;
    public List<string> inventory = new List<string>();
    public string weaponEquipped = "";
    // Start is called before the first frame update
    public bool ableToMove = true;
    public bool onTheHouse = false;
    public bool isInLake = true;
    public int attack = Animator.StringToHash("Hit");
    public DialogueController dialogueController;
   // DEBUG APPLE NPC public bool HasEaten { get; set; } = false; 


    void Start()
    {
        speed = 2.0f;
        setGraystoneVariables();
        Debug.Log(gameObject.name);
        animator = GetComponent<Animator>();
        animator.SetBool(canRun, true);
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


        if (!Front() || ableToMove || !Input.GetKey("w") || !(Input.GetKey("w") && (Input.GetKey("a") || Input.GetKey("d"))))
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
            }
            else
            {
                speed = 2.0f;
                animator.SetBool(isWalkingHash, false);
            }

            if ((Input.GetMouseButton(0)) && weaponEquipped != "")
            {
                Debug.Log("Player attacks");
                //attack
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                // DEBUG APPLE NPC HasEaten = true;
                if (dialogueController.FirstTimeHit == 0)
                {
                    setFirstHit(1);
                }
                else if (dialogueController.FirstTimeHit == 1)
                {
                    setFirstHit(2);
                }

                StartCoroutine(Attack());
                Debug.Log("Pegó");
            }
        }
        else
        {
            animator.SetBool(isWalkingHash, false);
        }
        if (Input.GetKeyDown("space"))
        {
            string m = "";
            for (int i = 0; i < inventory.Count; i++)
            {
                m += inventory[i];
            }
            Debug.Log(m);
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
        if (Input.GetKey("w") && (other.GetComponent<Collider>().gameObject.name != "Terrain"))
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
        yield return new WaitForSeconds(0.5f);
        animator.SetBool(attack, false);
    }


}
