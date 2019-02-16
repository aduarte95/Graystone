using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    private GameObject[] list;
    // Start is called before the first frame update
    void Start()
    {
      list = GameObject.FindGameObjectsWithTag("Apple");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.name == "Player")
        {
            int x = (int)Random.Range(0.0f, 9f);
            list[x].GetComponent<Apple>().DropApple();
        }
    }



}
