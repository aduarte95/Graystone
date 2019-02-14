using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeSceneController : SceneController
{
    public override void setScenePosition()
    {
        Debug.Log("lake");
        scenePosition = new Vector3(673.34f, 0.004f, 405f);
    }
}