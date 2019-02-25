using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    protected bool goAhead = false;
    public Text pressButton;
    protected string text;
    protected string objectName;

    public void Update()
    {
        if (goAhead)
        {
            setText();
            setPressText();
            if (Input.GetKeyDown("q"))
            {
                interact();
            }
        }
    }

    public void Start()
    {
        pressButton.text = "";
        setText();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            setPressText();
            goAhead = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cleanText();
        }
    }

    public void cleanText()
    {
        pressButton.text = "";
        goAhead = false;
        setOtherVariables();
    }

    protected void setPressText()
    {
        pressButton.text = text + objectName;
    }

    virtual public void setOtherVariables()
    {
    
    }

    virtual public void interact()
    {

    }

    virtual public void setText()
    {

    }
}
