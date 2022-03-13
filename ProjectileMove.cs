using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 3f;
    [SerializeField] float damage = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
        transform.Rotate(180f * projectileSpeed * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }   
    }
}
