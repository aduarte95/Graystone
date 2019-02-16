using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Animator animator;
    public DialogueTrigger dialogueTrigger;
    public PlayerController player;
    public Transform targetPosition;
    protected int MoveSpeed = 4;
    protected int MaxDist = 10;
    protected int MinDist = 2;
    protected int isWalkingHash = Animator.StringToHash("IsWalking");
    protected bool canTalk = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            
        }

    protected void walk()
    {
        animator.SetBool("IsWalking", true);
        transform.LookAt(targetPosition);

        // DEBUG APPLE NPC
        /*if (Vector3.Distance(transform.position, targetPosition.position) > MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        }
        else
        {
            animator.SetBool(isWalkingHash, false);
            MoveSpeed = 0;
            stopWalk();
        }*/
    }

    virtual public bool CanWalk()
    {
        return false;
    }

    virtual public void stopWalk()
    {

    }
}
