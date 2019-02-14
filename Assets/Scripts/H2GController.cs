using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2GController : SceneController
{
    public PlayerController playerController;

    override public void setObjects()
    {
        objects[MAIN].SetActive(isOn);
        objects[HOUSE].SetActive(!isOn);
        playerController.setOnTheHouse(false);
    }

    public override void setScenePosition()
    {
        scenePosition = new Vector3(767.86f, 0.004f, 236.72f);
    }
}