using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    static Animator animator;
    int isWalkingHash = Animator.StringToHash("IsWalking");

    public float speed = 2.0f;
    public int direction = 1;


    float random;
    public float chanceOfCurrency = 0.005f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
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
            }
            else
            {
                transform.Rotate(0, 180, 0);
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
            Debug.Log("***************ALIEN**********************************Hay algo al frente*******************************************");
            return true;
        }
        else
        {
            Debug.Log("No hay algo al frente");
            return false;
        }
    }
}
