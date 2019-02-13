using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectVisibilityController : MonoBehaviour
{
    bool isActiveAndEnabled;
    bool keyIsEnable = false;
    public GameObject chair;

    public void Update()
    {
      if(keyIsEnable && Input.GetKeyDown("q"))
        {
            chair.SetActive(!chair.activeSelf);
        }  
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (!keyIsEnable && collision.gameObject.tag == "Player")
        {
            Debug.Log("Colission");
            keyIsEnable = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (keyIsEnable && other.gameObject.tag == "Player")
        {
            Debug.Log("Colission exit");
            keyIsEnable = false;
        }
    }
}
