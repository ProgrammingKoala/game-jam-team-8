using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _attackCooldown;
    private Animator _animator; 

    private void Start()
    {
        _animator= GetComponentInParent<Animator>();
        Debug.Log(_animator.name+" "+ _animator.GetBool("isOnCooldown"));
    }

    private void Attack(bool isAttacking)
    {
        if(isAttacking)
        {
            if (!_animator.GetBool("isOnCooldown"))
            {
                StartCoroutine(AttackCoroutine());
            }
        }
        else
        {
            StopCoroutine(AttackCoroutine());
        }
    }


    private IEnumerator AttackCoroutine()
    {
        GameEvents.onPlayerTakeDamage();
        _animator.SetBool("isOnCooldown", true);
        Debug.Log(_animator.name + " " + _animator.GetBool("isOnCooldown"));
        yield return new WaitForSeconds(_attackCooldown);
        _animator.SetBool("isOnCooldown", false);
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
