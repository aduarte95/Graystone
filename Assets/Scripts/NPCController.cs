using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    protected const int APPLE_MISSION = 0;
    protected const int CANDLE_MISSION = 1;
    protected const int BLUEBERRY_MISSION = 2;
    public Animator animator;
    public DialogueTrigger dialogueTrigger;
    public PlayerController player;
    public bool CanTalk { get;  set; } = false;
    public string Name { get; protected set; }
    public Transform targetPosition;
    public MissionState missionsGame;
    public GameController gameController;
    protected int notInMission;

    // Start is called before the first frame update
    void Start()
    {
        notInMission = dialogueTrigger.dialogues.Length - 1;
        animator = GetComponent<Animator>();
        setName();
    }

    virtual public void setName()
    {

    }
}
