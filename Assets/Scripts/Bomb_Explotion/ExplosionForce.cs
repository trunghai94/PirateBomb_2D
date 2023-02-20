using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionForce : MonoBehaviour
{
    private float explosionForce = 1.5f;
    private float explosionRadius = 1.5f;
    public float upwardsModifier = 0.5f;

    private void Update()
    {
        if(CharacterBomb.checkExplosion == true)
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<Rigidbody2D>() != null/* && !collider.CompareTag("Bomb")*/) // Nếu tìm thấy Collider2D khác Bomb.
            {
                Rigidbody2D affectedRB = collider.GetComponent<Rigidbody2D>();
                Vector3 explosionDirection = (affectedRB.transform.position - transform.position);
                float distance = explosionDirection.magnitude;
                explosionDirection = explosionDirection.normalized;
                affectedRB.AddForce(explosionDirection * explosionForce * (1 - distance / explosionRadius) + (explosionDirection * upwardsModifier), ForceMode2D.Impulse);
            }
        }
    }

}
