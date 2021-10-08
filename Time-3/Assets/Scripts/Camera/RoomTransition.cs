using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        PopulateRoom populateRoomScript = GetComponent<PopulateRoom>();
        if(other.CompareTag("Player"))
        {
            if(CamController.instance.currentRoom.GetComponent<PopulateRoom>() != null)
            {
                CamController.instance.currentRoom.GetComponent<PopulateRoom>().Despawn();
            }
            
            CamController.instance.currentRoom = gameObject;

            if(populateRoomScript != null)
            {
                if(populateRoomScript.GetPopulated() == false)
                {
                    populateRoomScript.Populate();
                }
                else
                {
                    populateRoomScript.Respawn();
                }
            }
        }   
    }
}
