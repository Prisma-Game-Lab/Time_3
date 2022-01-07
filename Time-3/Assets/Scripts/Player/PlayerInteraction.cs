using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject NPCnearby;
    public GameObject DialogueManager;
	public bool isDialogueActive;
	public void onInteract(InputAction.CallbackContext context){
		if (context.performed){ //O input sistem ativa essa função 3 vezes(Started, PERFORMED e ended) logo só estou ativando no performed
			float dist = Vector2.Distance(NPCnearby.transform.position, transform.position);
			if((dist<=2)&&(isDialogueActive==false)){
				NPCnearby.GetComponent<NPCbase>().TriggerDialogue();
				isDialogueActive = true;
			}
			else if(isDialogueActive==true){
				DialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
			}
		}
	}
	public void DisableDialogue(){
		isDialogueActive=false;
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("NPC")) {
			NPCnearby = other.gameObject;
		}
	}
}
