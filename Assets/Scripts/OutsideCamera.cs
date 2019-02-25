using UnityEngine;
using System.Collections;
 
public class OutsideCamera : MonoBehaviour
{
    private Vector3 cameraOffset;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraOffset = new Vector3(0,20,-13);
        
    }

    private void Update()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}