using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;

    public int maxRooms;
    public int minRooms;

    public int totalRooms;
    public int rand;

    private void Awake() 
    {
        rand = Random.Range(minRooms, maxRooms);
    }
}
