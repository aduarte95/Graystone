
using UnityEngine.SceneManagement;
using UnityEngine;

public class HouseSceneController : SceneController
{
    public PlayerController playerController;
    public DialogueController dialogueController;

    override public void setObjects()
    {
        objects[HOUSE].SetActive(isOn);
        objects[MAIN].SetActive(!isOn);
        playerController.setOnTheHouse(true);
        dialogueController.setIsOnTheHouse();
    }

    public override void setScenePosition()
    {
        scenePosition = new Vector3(-49.6f, 0.004f, 24.33f);
    }

}
