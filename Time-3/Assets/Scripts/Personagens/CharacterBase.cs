using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

//Permite a criacao de instancias do SO pela janela "Project". -Arthur
[CreateAssetMenu(fileName = "Novo personagem", menuName = "Personagem")]
public class CharacterBase : ScriptableObject
{
    [Header("Atributos do jogador")]
    public int baseHp;
    public float baseDefense;
    public float baseSpeed;

    [Tooltip("Dano do ataque basico")]
    public int baseDamage;

    [Tooltip("Dano da habilidade de combate")]
    public int baseSkillDmg;

    public SkillBase basicAttack;

    public SkillBase[] Skills;
    [Header("Sprites")]
    public Sprite head;
    public Vector3 headOffset;
    public Sprite sprite;
    public RuntimeAnimatorController animatorController;

    public string attackSound;
    public string combatSkillSound;

}

