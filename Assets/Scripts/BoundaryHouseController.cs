using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoundaryHouseController : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = "River Scene";
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider collider)
    {
		Debug.Log("BOX COLLIDED!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        PlayerController player = collider.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Debug.Log("*******************************************************Loading: " + sceneName + "...");
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
