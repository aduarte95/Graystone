﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeSceneController : SceneController
{
    public override void setScenePosition()
    {
        Debug.Log("lake");
        scenePosition = new Vector3(680.9f, 0.004f, 244.9f);
    }
}