using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleFall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Hit!");
        
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("El arbol imprime Hit!");
    }
}
