using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headController : MonoBehaviour
{
    public GameObject head;
    public bool active;
    private void Start() {
        active = true;
    }
    private void Update() {
        hideHead();
    }
    private void hideHead(){
        if(active == false){
            head.SetActive(false);
        }
        else{
            head.SetActive(true);
        }
    }
}
