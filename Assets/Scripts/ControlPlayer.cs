using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(Vector3.left * 100);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(Vector3.right * 100);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce((new Vector3(0,0,1)) * 100);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce((new Vector3(0, 0, -1)) * 100);
    }
}
