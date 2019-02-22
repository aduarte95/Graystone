using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2GSceneController : SceneController
{
    public PlayerController playerController;

    public override void setScenePosition()
    {
        scenePosition = new Vector3(276.5f, 0.004f, 262.45f);

    }

    override public void setObjects()
    {
        playerController.setInLake(false);
    }
}
