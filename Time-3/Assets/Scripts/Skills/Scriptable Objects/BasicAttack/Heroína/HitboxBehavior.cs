using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxBehavior : MonoBehaviour
{
    [SerializeField] private HeroBasicAttackBehaviour attackBase;
    [SerializeField] private CharacterBase hero;
    private GameObject player;
    [SerializeField] private CharStats charStats; 
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Despawn());
    }
    private IEnumerator Despawn(){
        yield return new WaitForSeconds(attackBase.activeTime);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        IDamageable<int> damageable = other.gameObject.GetComponent<IDamageable<int>>();
		if (damageable != null && other.tag == "Enemy") 
        {
			damageable.ApplyDamage(hero.baseDamage);
		}
        if(other.tag != "Ignore" && other.tag != "Player")
        {
            Destroy(gameObject);   
        }
    }
}
