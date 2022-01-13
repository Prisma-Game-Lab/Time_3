using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDungeon : MonoBehaviour
{
    [SerializeField] private GameObject levelPopup;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            levelPopup.SetActive(true);
        }
    }
}
