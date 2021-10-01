using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    [SerializeField] private BasicBubble attackBase;
    [SerializeField] private CharacterBase fada;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * attackBase.speed);
        StartCoroutine(Despawn());
    }

    private IEnumerator Despawn()
    {
        float time = attackBase.range/attackBase.speed;
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        IDamageable<int> damageable = other.gameObject.GetComponent<IDamageable<int>>();
		if (damageable != null && other.tag == "Enemy") 
        {
			damageable.ApplyDamage(fada.baseDamage);
		}
        if(other.tag != "Ignore" && other.tag != "Player")
        {
            Destroy(gameObject);   
        }
    }
}
