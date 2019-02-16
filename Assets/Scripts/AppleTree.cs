using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.name == "Player")
        {
            Debug.Log("HIT");
            GameObject[] list = GameObject.FindGameObjectsWithTag("Apple");
            //GameObject.Find("FP_apple").GetComponent<Apple>().DropApple();
            foreach (GameObject apple in list)
            {
                Debug.Log(apple.GetComponent<Rigidbody>().position.y);
                if (apple.GetComponent<Rigidbody>().position.y == 6.4f)
                {
                    Debug.Log("Invoke drop");
                    apple.GetComponent<Apple>().DropApple();   
                }
            }
        }
    }



}
