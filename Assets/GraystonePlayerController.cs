using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraystonePlayerController : PlayerController
{
    override public void setVariables()
    {
        speed = 2.0f;
        acceleration = 5.0f;
        maxSpeed = 10.0f;
    }
}
