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
        playerController.setInLake(true);
        playerController.setOnTheHouse(true);
        dialogueController.IsOnTheHouse = true;
    }

    public override void setScenePosition()
    {
        scenePosition = new Vector3(-49.6f, 0.004f, 24.98f);
    }

}
