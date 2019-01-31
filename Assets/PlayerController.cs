using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static Animator animator;
    int isWalkingHash = Animator.StringToHash("IsWalking");
    public float speed = 2.0f;
    public float rotationSpeed = 75.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        //transform.Translate(0, 0, translation);
        //transform.Rotate(0, rotation, 0);

        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left * translation);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right *translation);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce((new Vector3(0, 0, 1)) * translation);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce((new Vector3(0, 0, -1)) * 10);

        if (translation != 0)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else
        {
            animator.SetBool(isWalkingHash, false);
        }
    }
}
