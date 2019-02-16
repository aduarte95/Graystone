using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropApple()
    {
        var apple = Instantiate(gameObject, gameObject.transform,true);
        apple.GetComponent<Rigidbody>().useGravity = true;
        Debug.Log("FALL");
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.name == "Terrain")
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }


}
