using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxBehavior : MonoBehaviour
{
    [SerializeField] private HeroBasicAttackBehaviour attackBase;
    [SerializeField] private CharacterBase hero;
    public GameObject player;
    void Start() {
        StartCoroutine(Despawn());
    }
    private void Update() {
        //transform.position = 
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
