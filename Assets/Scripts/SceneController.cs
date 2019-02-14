﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    protected string tag;
    protected Vector3 scenePosition;
    protected const int HOUSE = 0;
    protected const int MAIN = 1;
    protected const int PLAYER = 2;
    public GameObject[] objects;
    protected bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {
        objects[HOUSE].gameObject.SetActive(false);
        tag = "Player";
        setScenePosition();
    }

    virtual public void setScenePosition()
    {

    }

    virtual public void setObjects()
    {

    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == tag)
        {
            Debug.Log("Collision");
            collision.gameObject.transform.position = scenePosition;
            setObjects();
            //SceneManager.MoveGameObjectToScene(collision.gameObject, SceneManager.GetSceneByName(scenesName));
        }
    }
}
