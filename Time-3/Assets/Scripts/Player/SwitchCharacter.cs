using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchCharacter : MonoBehaviour
{
    [SerializeField] private CharacterBase[] Heroes;
    private CharStats charstats;
    private PlayerActions playerinput;
    
    private void Awake() {
        playerinput = new PlayerActions();
    }

    void Start()
    {
        charstats=GetComponent<CharStats>();
        //Pode ser uma variável global para um personagem default/favorito
        SwitchHero(0);
    }

    // Update is called once per frame

    public void hero1(InputAction.CallbackContext context){
        if (!context.ReadValueAsButton() || context.performed) return;
        SwitchHero(0);
    }
        public void hero2(InputAction.CallbackContext context){
        if (!context.ReadValueAsButton() || context.performed) return;
        SwitchHero(1);
    }
        public void hero3(InputAction.CallbackContext context){
        if (!context.ReadValueAsButton() || context.performed) return;
        SwitchHero(2);
    }
    private void SwitchHero(int index)
    {
        charstats.setCharbase(Heroes[index]);
    }
}
