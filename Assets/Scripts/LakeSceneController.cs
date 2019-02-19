using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeSceneController : SceneController
{
    public PlayerController playerControler;
    public override void setScenePosition()
    {
        Debug.Log("lake");
        scenePosition = new Vector3(680.4945f, 0.004f, 255.4891f);


    }

    override public void setObjects()
    {
        playerControler.setInLake(true);
    }
}