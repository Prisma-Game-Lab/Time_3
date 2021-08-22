using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour
{
    [SerializeField] private CharacterBase charBase; //Referencia ao SO do personagem.
    [SerializeField] private Skill[] skills; //Array contendo as habilidades dos personagens. -Arthur 

    [SerializeField] private int maxHp;
    [SerializeField] private int defense;
    [SerializeField] private int speed;
    [SerializeField] private int damage;
    [SerializeField] private int skillDmg;

    private int curr_hp;


    // Start is called before the first frame update
    void Start()
    {
        //Status definidos a partir do SO. -Arthur
        maxHp = charBase.baseHp;
        defense = charBase.baseDefense;
        speed = charBase.baseSpeed;
        damage = charBase.baseDamage;
        skillDmg = charBase.baseSkillDmg;

        curr_hp = maxHp; //Vida atual deve ser inicializada como a vida maxima. -Arthur 
    }
}
