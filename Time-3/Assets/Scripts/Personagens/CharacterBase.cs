using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Permite a criacao de instancias do SO pela janela "Project". -Arthur
[CreateAssetMenu(fileName = "Novo personagem", menuName = "Personagem")]
public class CharacterBase : ScriptableObject
{
    [Header("Atributos do jogador")]
    public int baseHp;
    public int baseDefense;
    public float baseSpeed;

    [Tooltip("Dano do ataque basico")]
    public int baseDamage;

    [Tooltip("Dano da habilidade de combate")]
    public int baseSkillDmg;
}
