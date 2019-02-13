﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    static Animator animator;
    int isWalkingHash = Animator.StringToHash("IsWalking");
    int getHitHash = Animator.StringToHash("GetHit");
    int dieHash = Animator.StringToHash("Dies");
    int attack1Hash = Animator.StringToHash("Attack1");
    int attack2Hash = Animator.StringToHash("Attack2");

    bool ableToMove;
    public float speed = 2.0f;
    public int direction = 1;

    float random;
    public float chanceOfCurrency = 0.005f;
    Rigidbody rb;

    public float currentHealth { get; set; }
    public float maxHealth { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        maxHealth = 30f;
        currentHealth = maxHealth;

        ableToMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ableToMove)
        {
            float translation = direction * speed;
            translation *= Time.deltaTime;
            Vector3 move = new Vector3(0, 0, translation);

            random = Random.value;
            if (random < chanceOfCurrency)
            {
                transform.Rotate(0, 90, 0);
            }

            RaycastHit hit;

            if (!GetComponent<Rigidbody>().SweepTest(transform.forward, out hit, speed * Time.deltaTime + 0.01f))
            {
                if (!Front())
                {
                    transform.Translate(0, 0, translation);
                    animator.SetBool(isWalkingHash, true);
                }
                else
                {
                    transform.Rotate(0, 180, 0);
                    animator.SetBool(isWalkingHash, false);
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(doAttack1());
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(doAttack2());
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(dealDamage(10));
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
            //Debug.Log("***************ALIEN**********************************Hay algo al frente*******************************************");
            return true;
        }
        else
        {
            return false;
        }
    }

    // Reduce the health in "damageValue" points
    IEnumerator dealDamage(float damageValue)
    {
        currentHealth -= damageValue;
        // if health gets negative passes to 0
        if (currentHealth > 0)
        {
            animator.SetBool(getHitHash, true);
            yield return new WaitForSeconds(0.5f);
            animator.SetBool(getHitHash, false);
        }
        else
        {
            currentHealth = 0;
            ableToMove = false;
            animator.SetBool(dieHash, true);
        }
    }

    IEnumerator doAttack1()
    {
        animator.SetBool(attack1Hash, true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool(attack1Hash, false);
    }

    IEnumerator doAttack2()
    {
        animator.SetBool(attack2Hash, true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool(attack2Hash, false);
    }
}
