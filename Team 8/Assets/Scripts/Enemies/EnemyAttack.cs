using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private SpriteRenderer _sr;
    private bool _onCooldown;
    [SerializeField] private float _attackCooldown;
    private bool _isAttacking;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.color = Color.clear;
    }

    private void Attack()
    {
        if(!_onCooldown)
        {
            StartCoroutine(AttackEnume(_attackCooldown));
        }
    }


    private IEnumerator AttackEnume(float secons)
    {
        _onCooldown = true;
        _sr.color = Color.white;
        _isAttacking= true;
        yield return new WaitForSeconds(0.5f);
        _isAttacking = false;
        _sr.color = Color.clear;
        yield return new WaitForSeconds(secons);
        _onCooldown = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isAttacking && collision.gameObject.CompareTag("Player"))
        {
            GameEvents.onPlayerTakeDamage();
        }
    }

    private void OnEnable()
    {
        GameEvents.onEnemyAttack += Attack;
    }

    private void OnDisable()
    {
        GameEvents.onEnemyAttack -= Attack;
    }
}
