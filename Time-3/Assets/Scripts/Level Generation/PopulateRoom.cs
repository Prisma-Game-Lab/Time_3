using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulateRoom : MonoBehaviour
{
    [SerializeField] private List<GameObject> roomObjects = new List<GameObject>();
    [SerializeField] private int totalObjects;

    [SerializeField] private List<GameObject> spawnedObjects = new List<GameObject>();
    private bool populated = false;

    public void Populate()
    {
        for(int i = 0; i < totalObjects; i++)
        {
            float xPosition = Random.Range(-5,5);
            float yPosition = Random.Range(-2,2);
            int objectIndex = Random.Range(0, roomObjects.Count);

            GameObject spawnedObject = Instantiate(roomObjects[objectIndex], new Vector3(xPosition,yPosition,0.0f) + gameObject.transform.position, Quaternion.identity);
            spawnedObjects.Add(spawnedObject);
        }
        populated = true;
    }

    public void Despawn()
    {
        for(int i = 0; i < spawnedObjects.Count; i++)
        {
            spawnedObjects[i].SetActive(false);
        }
    }

    public void Respawn()
    {
        for(int i = 0; i < spawnedObjects.Count; i++)
        {
            spawnedObjects[i].SetActive(true);
        }
    }

    public bool GetPopulated()
    {
        return populated;
    }
}
