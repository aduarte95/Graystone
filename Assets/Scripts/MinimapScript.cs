using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    public PlayerController player;

    private Vector3 newPosition;

    void Update()
    {
        bool isInLake = player.isInLake;
        if (isInLake)
        {
            newPosition = new Vector3(815, 20, 153);
        }

        else
        {
            newPosition = new Vector3(152, 20, 153);
        }

        transform.position = newPosition;


    }
}
