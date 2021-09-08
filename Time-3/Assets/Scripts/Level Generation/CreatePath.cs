using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Path") && transform.GetChild(0).gameObject.activeSelf == false)
        {
            int rand = Random.Range(0, 2);
            if(rand == 0)
            {
                other.gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
