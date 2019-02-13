using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GraystoneForestBoundaryController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	void Update(){
		
	}

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision");
            SceneManager.LoadScene("Forest", LoadSceneMode.Single);
            //SceneManager.MoveGameObjectToScene(collision.gameObject, SceneManager.GetSceneByName(scenesName));
        }
    }
}
