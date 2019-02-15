using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   public Dialogue[] dialogue;
    public bool cont;

    public void setContinue(bool cont) {
        this.cont = cont;
    }

    public void TriggerDialogue(int i) {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[i]);
    }
}
