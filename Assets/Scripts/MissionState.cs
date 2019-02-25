using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionState : MonoBehaviour
{
    private bool[] missions;

    void Start()
    {
        missions = new bool[6];
        for (int i = 0; i < 6; ++i)
        {
            missions[i] = false;
        }
    }

    public bool isFinished(int i)
    {
        bool result = false;

        if (i < 6)
        {
            result = missions[i];
        } else
        {
            Debug.Log("Out of bounds on mission array");
        }

        return result;
    }

    public void setFinished(int i)
    {
        if (i < 6)
        {
            missions[i] = true;
        }
        else
        {
            Debug.Log("Set out of bounds on mission array");
        }
    }
}
