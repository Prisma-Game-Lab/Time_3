using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection; // 1 = down, 2 = up, 3 = left, 4 = right -Arthur 
    public bool spawned = false;
    public bool isOverlaping = false;

    private RoomTemplates templates;
    private int rand;
    private int overlapIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 4.0f);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if(!spawned && templates.totalRooms < templates.rand)
        {
            if(openingDirection == 1)
            {
                //Cria sala com porta para baixo -Arthur
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if(openingDirection == 2)
            {
                //Cria sala com porta para cima -Arthur
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if(openingDirection == 3)
            {
                //Cria sala com porta para a esquerda -Arthur
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if(openingDirection == 4)
            {
                //Cria sala com porta para a direita -Arthur
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
            templates.totalRooms++;
        } 
        else if(!spawned)
        {
            gameObject.transform.parent.parent.GetChild(2).GetChild(3).GetChild(openingDirection - 1).gameObject.SetActive(true);
            spawned = true;
        }
        else if(isOverlaping)
        {
            GameObject closedRoom = Instantiate(templates.closedRoom, transform.position, templates.closedRoom.transform.rotation);
            if(openingDirection == 1)
            {
                closedRoom.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            }
            else if(openingDirection == 2)
            {
                closedRoom.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
            }
            else if(openingDirection == 3)
            {
                closedRoom.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(false);
            }
            else if(openingDirection == 4)
            {
                closedRoom.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(false);
            }

            if(overlapIndex == 1)
            {
                closedRoom.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            }
            else if(overlapIndex == 2)
            {
                closedRoom.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
            }
            else if(overlapIndex == 3)
            {
                closedRoom.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(false);
            }
            else if(overlapIndex == 4)
            {
                closedRoom.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Spawnpoint") && other.GetComponent<Destroyer>() == null)
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                isOverlaping = true;
                overlapIndex = other.GetComponent<RoomSpawner>().openingDirection;
            }
            spawned = true;
        }
    }
}
