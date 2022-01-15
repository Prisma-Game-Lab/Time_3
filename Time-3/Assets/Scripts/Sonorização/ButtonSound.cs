using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(PlayButtonSound);
    }
    public void PlayButtonSound()
    {
        FindObjectOfType<AudioManager>().Play("Botao");
    }
}
