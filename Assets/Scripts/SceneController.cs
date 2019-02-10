using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    protected string scenesName;

    // Start is called before the first frame update
    void Start()
    {
        setSceneName();
    }
    
    virtual public void setSceneName()
    {

    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision");
            SceneManager.LoadScene(scenesName, LoadSceneMode.Additive);
            //SceneManager.MoveGameObjectToScene(collision.gameObject, SceneManager.GetSceneByName(scenesName));
        }
    }
}
