using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2GController : SceneController
{
    override public void setCamera()
    {
        cameras[MAIN].gameObject.SetActive(isOn);
        cameras[HOUSE].gameObject.SetActive(!isOn);
    }

    public override void setScenePosition()
    {
        scenePosition = new Vector3(798.69f, 0.004f, 411.54f);
    }
}