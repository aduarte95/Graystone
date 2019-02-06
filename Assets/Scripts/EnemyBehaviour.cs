using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    static Animator animator;
    int isWalkingHash = Animator.StringToHash("IsWalking");

    public float speed = 2.0f;
    public int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = direction * speed;
        translation *= Time.deltaTime;
        Vector3 move = new Vector3(0, 0, translation); 
        transform.Translate(move);

        if (translation != 0)
        {
            animator.SetBool(isWalkingHash, true);
        }

        RaycastHit[] results = new RaycastHit[16];

        //int cnt = GetComponent<Rigidbody>().Cast(move, results, move.magnitude + 0.01f); //This not work 
        //if (cnt > 0)

        if (results != null) //with this the alien does not move at all
        {
            direction *= -1;
        }
    }
}
