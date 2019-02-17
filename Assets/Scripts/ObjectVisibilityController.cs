using UnityEngine;

public class ObjectVisibilityController : ObjectInteraction
{
    public GameObject objectToHide;

    override public void interact()
    {
		Pickup p = objectToHide.GetComponent<Pickup>();
		InventoryController ic = GameObject.Find("Player").GetComponent<InventoryController>();
		if(!objectToHide.activeSelf){
			Debug.Log("A");
			ic.putItem(objectToHide);
			objectToHide.SetActive(true);
		}
		else
		{
			Debug.Log("B");
			ic.takeItem(objectToHide);
			objectToHide.SetActive(false);
		}
	}

    override public void setText()
    {
        if (objectToHide.activeSelf)
        {
            text = "Press Q button to take ";
        }
        else
        {
            text = "Press Q button to put ";
        }
        
        objectName = objectToHide.name;
    }
}
