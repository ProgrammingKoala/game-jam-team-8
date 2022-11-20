using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private SpriteRenderer _sr;
    private bool _onCooldown = false;
    [SerializeField] private float _attackCooldown;
    private bool _isAttacking;
    private bool _isTouchingPlayer;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.color = Color.clear;
        _isTouchingPlayer = false;
    }

    private void Attack(bool isAttacking)
    {
        if (isAttacking)
        {
            _isAttacking = true;
            StartCoroutine(AttackEnume(_attackCooldown));
        }
        else
        {
            isAttacking= false;
            StopCoroutine(AttackEnume(_attackCooldown));
        }
    }


    private IEnumerator AttackEnume(float seconds)
    {
        while(_isAttacking) {
            _onCooldown = true;
            _sr.color = Color.white;
            _isAttacking = true;
            yield return new WaitForSeconds(0.5f);
            _isAttacking = false;
            _sr.color = Color.clear;
            yield return new WaitForSeconds(seconds);
            _onCooldown = false;
            _isAttacking = true;
            if (_isTouchingPlayer)
            {
                GameEvents.onPlayerTakeDamage();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isTouchingPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isAttacking= false;
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
