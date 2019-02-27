using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    protected const int APPLE_MISSION = 0;
    protected const int CANDLE_MISSION = 1;
    protected const int BLUEBERRY_MISSION = 2;
    protected const int ASK_CHAIR_MISSION = 3;
    protected const int BERRY_ALIEN_DEAD = 4;
    protected const int ASK_BED_MISSION = 5;
    protected int notInMission;
    public Animator animator;
    public DialogueTrigger dialogueTrigger;
    public PlayerController player;
    public bool CanTalk { get; set; } = false;
    public string Name { get; protected set; }
    public Transform targetPosition;
    public MissionState missionsGame;
    public PositionController positionController;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        notInMission = dialogueTrigger.dialogues.Length - 1;
        animator = GetComponent<Animator>();
        setName();
    }

    private void Update()
    {
        if (CanTalk) //actives in position of npc
        {
            CanTalk = false;
            transform.LookAt(targetPosition);
            talk();
        }

        checkMission();
    }

    virtual public void talk()
    {

    }

    virtual public void checkMission()
    {

    }

    virtual public void setName()
    {

    }

    virtual public void setHasObject(int theObject)
    {

    }
}
