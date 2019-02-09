using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static Animator animator;
    int isWalkingHash = Animator.StringToHash("IsWalking");
    public float speed = 2.0f;
    public float acceleration = 5.0f;
    public float maxSpeed = 10.0f;
    public float rotationSpeed = 75.0f;
    // Start is called before the first frame update
    private bool ableToMove = true;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = 8.0f;
        if (!Front()||  ableToMove ||!Input.GetKey("w")|| !(Input.GetKey("w") && (Input.GetKey("a") || Input.GetKey("d"))))
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
        }
        else
        {
            animator.SetBool(isWalkingHash, false);
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
            Debug.Log("*************************************************Hay algo al frente*******************************************");
            return true;
        }
        else
        {
            Debug.Log("No hay algo al frente");
            return false;
        }
    }
    
    
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log( "collide (name) : " + collision.GetComponent<Collider>().gameObject.name );
         speed = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if( Input.GetKey("w") && (other.GetComponent<Collider>().gameObject.name != "Terrain"))
        {
            Debug.Log( "collide (name) : " + other.GetComponent<Collider>().gameObject.name );
            speed = 0;
            ableToMove = false;
            animator.SetBool(isWalkingHash, false);
            Debug.Log("Able to move has change");
        }
    }
    

    private void OnTriggerExit(Collider col)
    {
        Debug.Log("No hay obstáculos");
        animator.SetBool(isWalkingHash, true);
        ableToMove = true;
    }

}
