using UnityEngine;

public class ObjectVisibilityController : ObjectInteraction
{
    public GameObject objectToHide;

    override public void interact()
    {
		Pickup p = objectToHide.GetComponent<Pickup>();
		InventoryController ic = GameObject.Find("Player").GetComponent<InventoryController>();
		PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
		if(!objectToHide.activeSelf){
			if(ic.hasItem(objectToHide.tag)){
				ic.putItem(objectToHide);
				if (objectToHide.gameObject.CompareTag("Jug"))
				{
					player.hasJug = false;
					objectToHide.GetComponent<Renderer>().enabled = true;
				}
				objectToHide.SetActive(true);
			} else {Debug.Log("Player doesn't have that item");}
		}
		else
		{
			if(!ic.hasItem(objectToHide.tag)){
				ic.takeItem(objectToHide);
				objectToHide.SetActive(false);
				if (objectToHide.gameObject.CompareTag("Jug"))
				{
					Debug.Log("Enter here if it is a jug");
					player.hasJug = true;
					objectToHide.SetActive(true);
					objectToHide.GetComponent<Renderer>().enabled = false;
				}
				
				
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
        
        objectName = objectToHide.tag;
    }
}
