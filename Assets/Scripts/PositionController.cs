using UnityEngine;
using UnityEngine.UI;

public class PositionController : MonoBehaviour
{
    bool goAhead = false;
    public NPCController npc;
    public Text pressButton;

    public void Start()
    {
        pressButton.text = "";
    }

    public void Update()
    {
        if (goAhead && Input.GetKeyDown("q"))
        {
            npc.CanTalk = true;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pressButton.text = "Press Q button to talk to " + npc.Name;
            goAhead = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pressButton.text = "";
            goAhead = false;
            npc.CanTalk = false;
        }
    }
}
