using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchDetection : MonoBehaviour
{
    public Transform _transform;
    public float _attackRange = 0.1f;
    public LayerMask _enemyLayers;

    public void GetHits(float AttackDamage)
    {
        Collider[] hitEnemies = Physics.OverlapSphere(_transform.position, _attackRange, _enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(AttackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_transform.position, _attackRange);
    }
}
