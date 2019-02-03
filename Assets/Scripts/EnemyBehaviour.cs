using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce((new Vector3(0, 0, 1)) * 100);
    }

    public void CollideWithHorizontal(Collider other)
    {
        direction = -direction;
    }
}
