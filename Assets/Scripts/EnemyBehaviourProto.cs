using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviourProto : MonoBehaviour
{
    Rigidbody rb;

    public Animator animator;
    int isWalkingHash = Animator.StringToHash("IsWalking");
    int getHitHash = Animator.StringToHash("GetHit");
    int dieHash = Animator.StringToHash("Dies");
    int attack1Hash = Animator.StringToHash("Attack1");
    int attack2Hash = Animator.StringToHash("Attack2");

    public Transform Player;

    bool ableToMove;
    public float speed = 2.0f;
    public int direction = 1;
    public float MaxDist = 3;
    public int MinDist = 2;
    public bool didHit = false;
    public DialogueManager dialogueManager;
    float random;
    public float chanceOfCurrency = 0.005f;

    public float currentHealth { get; set; }
    public float maxHealth { get; set; }

    public PlayerHealth playerHealth;

    public PoisonLevel poisonLevel;

    public PlayerController player;
    public Transform target ;
    

    public DialogueController dialogueController; //Tells the dialogue that the alien is dead

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        maxHealth = 30f;
        currentHealth = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        ableToMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ableToMove)
        {
            // Random Movement
            /*
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
            */
            
            if (Input.GetKeyDown(KeyCode.J)) {
         
                float dist   = Vector3.Distance(transform.position, target.position);
                Vector3 toTarget = (target.position - transform.position).normalized;
             
                if (Vector3.Dot(toTarget, transform.forward) > 0 && dist < 2) {
                    Debug.Log("Target is in front of this game object.");
                } else {
                    Debug.Log("Target is not in front of this game object.");
                }
            }
            
            
            
            
            //follow movement
            if (dialogueManager.isActive == false)
            {
                transform.LookAt(Player);

                if (Vector3.Distance(transform.position, Player.position) >= 1)
                {
                    animator.SetBool(isWalkingHash, true);
                    transform.position += transform.forward * speed * Time.deltaTime;
                    if (!didHit)
                    {
                        float dist = Vector3.Distance(transform.position, target.position);
                        Vector3 toTarget = (target.position - transform.position).normalized;
                        if (Vector3.Dot(toTarget, transform.forward) > 0 && dist  <2)
                        {
                            StartCoroutine(doAttack1());
                        }
                    }
                }
                else
                {
                    animator.SetBool(isWalkingHash, false);
                    if (!didHit)
                    {
                        float dist = Vector3.Distance(transform.position, target.position);
                        Vector3 toTarget = (target.position - transform.position).normalized;
                        Debug.Log("Dist " + dist);
                        Debug.Log("Dot " + Vector3.Dot(toTarget, transform.forward));
                        if (Vector3.Dot(toTarget, transform.forward) > 0 && dist < 2)
                        {
                            StartCoroutine(doAttack2());

                        }
                        poisonLevel.getPoison(1);
                        player.isPoisoned = true;
                    }
                }

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
            //Debug.Log("***************ALIEN**********************************Hay algo al frente*******************************************");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void getHit(int damage)
    {
        StartCoroutine(dealDamage(damage));
    }

    // Reduce the health in "damageValue" points
   public  IEnumerator dealDamage(float damageValue)
    {
        Debug.Log("Perdio vida");
        currentHealth -= damageValue;
        // if health gets negative passes to 0
        if (currentHealth > 0)
        {
            animator.SetBool(getHitHash, true);
            //animator.SetTrigger("GetHit");
            yield return new WaitForSeconds(0.5f);
            animator.SetBool(getHitHash, false);
        }
        else
        {
            currentHealth = 0;
            ableToMove = false;
            animator.SetBool(dieHash, true);
            dialogueController.IsAlienDead = true; //Tells that the alien is dead
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false);
        }
    }

    IEnumerator doAttack1()
    {
        didHit = true;
        animator.SetBool(attack1Hash, true);
        playerHealth.dealDamage(10);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool(attack1Hash, false);
        didHit = false;
    }

    IEnumerator doAttack2()
    {
        didHit = true;
        animator.SetBool(attack2Hash, true);
        playerHealth.dealDamage(10);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool(attack2Hash, false);
        didHit = false;
    }  
}
