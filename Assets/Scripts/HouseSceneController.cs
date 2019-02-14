﻿
using UnityEngine.SceneManagement;
using UnityEngine;

public class HouseSceneController : SceneController
{
    public PlayerController playerController;

    override public void setObjects()
    {
        objects[HOUSE].SetActive(isOn);
        objects[MAIN].SetActive(!isOn);
        playerController.setOnTheHouse(true);
    }

    public override void setScenePosition()
    {
        scenePosition = new Vector3(-137.03f, 0.004f, 24.78f);
    }

}
