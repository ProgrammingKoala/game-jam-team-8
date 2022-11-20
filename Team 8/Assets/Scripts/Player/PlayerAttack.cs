using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton(ButtonNames.Attack) && !_onCooldown)
        {
            StartCoroutine(Attack(_attackCooldown));
        }
    }

    private IEnumerator Attack(float secons)
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
        if (_isAttacking && collision.gameObject.CompareTag("Enemy"))
        {
            GameEvents.onEnemyTakeDamage();
        }
    }
}
