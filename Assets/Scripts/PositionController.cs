using UnityEngine;

public class PositionController : ObjectInteraction
{
    public NPCController npc;

    override public void setOtherVariables()
    {
        npc.CanTalk = false;
    }

    override public void interact()
    {
        npc.CanTalk = true;
    }

    override public void setText()
    {
        text = "Press Q button to talk to ";
        objectName = npc.Name;
    }
    
}
