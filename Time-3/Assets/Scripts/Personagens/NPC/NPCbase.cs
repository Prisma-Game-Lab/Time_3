using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCbase : MonoBehaviour
{
    public Dialogue[] dialogues;
    private Dialogue dialogue;

    private void Start() 
    {
        int dialogueIndex = Random.Range(0, dialogues.Length);
        dialogue = dialogues[dialogueIndex];
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
