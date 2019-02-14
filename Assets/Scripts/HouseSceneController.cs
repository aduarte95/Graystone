
using UnityEngine.SceneManagement;
using UnityEngine;

public class HouseSceneController : SceneController
{
    override public void setCamera()
    {
        cameras[HOUSE].gameObject.SetActive(isOn);
        cameras[MAIN].gameObject.SetActive(!isOn);
    }

    public override void setScenePosition()
    {
        scenePosition = new Vector3(-49.52f, 0.004f, 24.31f);
    }

}
