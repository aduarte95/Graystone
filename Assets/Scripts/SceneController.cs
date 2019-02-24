using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    protected string tag;
    public Vector3 scenePosition;
    protected const int HOUSE = 0;
    protected const int MAIN = 1;
    protected const int PLAYER = 2;
    public GameObject[] objects;
    protected bool isOn = true;
    public DialogueController dialogueController; //PROTO

    // Start is called before the first frame update
    void Start()
    {
        objects[MAIN].gameObject.SetActive(false); //CHANGE
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
        if (collision.gameObject.tag == tag && dialogueController.FinishedHouse) //PROTO alien dead QUITAR SEGUNDA CONDICON SI QUIEREN SALIR DE LA CASA :)
        {
            collision.gameObject.GetComponent<CharacterController>().enabled = false;
            collision.gameObject.transform.position = scenePosition;
            collision.gameObject.GetComponent<CharacterController>().enabled = true;
            setObjects();
            Debug.Log(name);
            //SceneManager.MoveGameObjectToScene(collision.gameObject, SceneManager.GetSceneByName(scenesName));
        }
    }
}
