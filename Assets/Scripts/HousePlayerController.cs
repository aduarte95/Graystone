using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePlayerController : PlayerController
{
    override public void setVariables()
    {
        speed = 500.0f;
        acceleration = 0.0f;
        maxSpeed = 500.0f;
    }
}
