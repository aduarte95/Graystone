using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormBehaviour : MonoBehaviour
{
    public DialogueController dialogueController; 

    public Transform Sphere;

    public Transform Player;
    public PlayerHealth playerHealth;
    public PoisonLevel poisonLevel;
    public PlayerController player;

    Rigidbody rb;
    private Animator animator;
    int isWalkingHash = Animator.StringToHash("IsWalking");
    int getHitHash = Animator.StringToHash("GetHit");
    int dieHash = Animator.StringToHash("Dies");
    int attack1Hash = Animator.StringToHash("Attack1");
    int attack2Hash = Animator.StringToHash("Attack2");

    bool ableToMove;
    bool isDead;
    public float speed = 2.0f;
    public int direction = 1;
    public float MaxDistS = 15;
    public float MaxDist = 3;
    public int MinDist = 1;
    public float MaxTime = 10;
    public bool turn;
    public bool didHit = false;

    public float currentHealth { get; set; }
    public float maxHealth { get; set; }

    float random;
    public float chanceOfCurrency = 0.025f;

    public SugarNPC sugar;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        maxHealth = 30f;
        currentHealth = maxHealth;

        ableToMove = true;
        isDead = false;
        turn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ableToMove)
        {

            if ((Vector3.Distance(transform.position, Sphere.position) < MaxDistS) || (turn))
            {
                animator.SetBool(isWalkingHash, true);
                transform.position += transform.forward * speed * Time.deltaTime * -1;
                if (turn)
                    turn = false;
            }
            else
            {
                if (!turn)
                {
                    animator.SetBool(isWalkingHash, false);
                    transform.Rotate(0, 180, 0);
                    turn = true;
                }
            }

            
            MaxTime -= Time.deltaTime;
            if (MaxTime <= 0)
            {
                random = Random.value;
                if (random < chanceOfCurrency)
                {
                    transform.Rotate(0, 90, 0);
                    MaxTime = 10;
                }
            }
        }
        else
        {
            animator.SetBool(isWalkingHash, false);
        }
    }

    public void getHit(int damage)
    {
        StartCoroutine(dealDamage(damage));
    }

    // Reduce the health in "damageValue" points
    IEnumerator dealDamage(float damageValue)
    {
        if (!isDead)
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
                sugar.AliensAreDead ++; //Tells that the alien is dead
                gameObject.SetActive(false);
                isDead = true;
            }
        }
    }
}
