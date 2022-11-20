using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private SpriteRenderer _sr;
    private bool _attackOnCooldown;
    private bool _parryOnCooldown;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private float _parryCooldown;
    private bool _isAttacking;
 
    void Start()
    {      
        _sr = GetComponentInChildren<SpriteRenderer>();
        _sr.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton(ButtonNames.Attack) && !_attackOnCooldown)
        {
            StartCoroutine(Attack(_attackCooldown));
        }
        if (Input.GetButton(ButtonNames.Parry) && !_parryOnCooldown)
        {
            StartCoroutine(Parry(_parryCooldown));
        }
    }

    private IEnumerator Attack(float seconds)
    {
        _attackOnCooldown = true;
        _sr.color = Color.white;
        _isAttacking= true;
        yield return new WaitForSeconds(0.5f);
        _isAttacking = false;
        _sr.color = Color.clear;

        yield return new WaitForSeconds(seconds);

        _attackOnCooldown = false;
    }

    private IEnumerator Parry(float seconds)
    {
        _parryOnCooldown = true;
        _sr.color = Color.green;
        GameStatics.playerIsParrying = true;
        yield return new WaitForSeconds(0.7f);
        GameStatics.playerIsParrying = false;
        _sr.color = Color.clear;

        yield return new WaitForSeconds(seconds);

        _parryOnCooldown = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isAttacking && collision.gameObject.CompareTag("Enemy"))
        {
            GameEvents.onEnemyTakeDamage();
        }
    }
}
