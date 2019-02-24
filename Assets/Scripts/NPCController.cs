using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Animator animator;
    public DialogueTrigger dialogueTrigger;
    public PlayerController player;
    public bool CanTalk { get;  set; } = false;
    public string Name { get; protected set; }
    public Transform targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        setName();
    }

    virtual public void setName()
    {

    }
}
