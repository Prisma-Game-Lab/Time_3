using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public SpriteRenderer sprite;
    public Animator animator;
    private Queue<string> sentences;
    public GameObject player;
    void Start() {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        player.GetComponentInChildren<PlayerMovementBehaviour>().enabled = false;
        animator.SetBool("IsOpen",true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentenc in dialogue.sentences)
        {
            sentences.Enqueue(sentenc);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence(){
        if (sentences.Count==0){
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }
    void EndDialogue(){
        player.GetComponentInChildren<PlayerMovementBehaviour>().enabled = true;
        animator.SetBool("IsOpen",false);
        player.GetComponentInChildren<PlayerInteraction>().DisableDialogue();
    }
}
