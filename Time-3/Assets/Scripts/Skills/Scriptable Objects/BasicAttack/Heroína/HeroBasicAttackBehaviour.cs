using UnityEngine;

[CreateAssetMenu(fileName = "HeroAttack", menuName = "BasicAttacks/HeroAttack")]

public class HeroBasicAttackBehaviour : SkillBase
{
    //Para alterar o hitbox é só mexer no prefab da skill 
    [SerializeField] private GameObject Hitbox;
    [SerializeField] float angulo = -18;
    private GameObject player;
    public override void TriggerSkill(){
        player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(Hitbox, player.transform.position + player.transform.right, player.transform.rotation*Quaternion.Euler(0,0,angulo));
    }
    public override void StopSkill(){

    }
}
