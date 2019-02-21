using UnityEngine;

public class ObjectVisibilityController : ObjectInteraction
{
    public GameObject objectToHide;

    override public void interact()
    {
		Pickup p = objectToHide.GetComponent<Pickup>();
		InventoryController ic = GameObject.Find("Player").GetComponent<InventoryController>();
		if(!objectToHide.activeSelf){
			if(ic.hasItem(objectToHide.name)){
				ic.putItem(objectToHide);
				objectToHide.SetActive(true);
			} else {Debug.Log("Player doesn't have that item");}
		}
		else
		{
			if(!ic.hasItem(objectToHide.name)){
				ic.takeItem(objectToHide);
				objectToHide.SetActive(false);
			} else {Debug.Log("Player already has that item");}
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
