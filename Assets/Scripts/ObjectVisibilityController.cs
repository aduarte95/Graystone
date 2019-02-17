using UnityEngine;

public class ObjectVisibilityController : ObjectInteraction
{
    public GameObject objectToHide;

    override public void interact()
    {
        objectToHide.SetActive(!objectToHide.activeSelf);
    }

    override public void setText()
    {
        if (objectToHide.activeSelf)
        {
            text = "Press Q button to keep away ";
        }
        else
        {
            text = "Press Q button to put ";
        }
        
        objectName = objectToHide.name;
    }
}
