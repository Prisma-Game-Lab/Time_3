using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{

    public static CamController instance;
    public GameObject currentRoom;
    public float moveSpeed;

    private void Awake() 
    {
        instance = this;
    }
    
    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition() 
    {
        if(currentRoom == null)
        {
            return;
        }

        Vector3 targetPos = GetCameraTargetPosition();

        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
    }

    Vector3 GetCameraTargetPosition()
    {
        if(currentRoom == null)
        {
            return Vector3.zero;
        }   

        Vector3 targetPos = currentRoom.transform.position;
        targetPos.z = transform.position.z;

        return targetPos;
    }
}
