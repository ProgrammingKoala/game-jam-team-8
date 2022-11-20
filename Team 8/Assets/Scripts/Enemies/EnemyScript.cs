using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private GameObject _player;
    [SerializeField] int HP;
    [SerializeField] private float _takeDamageCooldown;
    private bool _damageOnCooldown;
    private bool _isDying;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _isDying= false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_player == null) { _player = GameObject.FindGameObjectWithTag("Player");  }
        float distanceFromPlayer = Mathf.Abs(_rb.transform.position.x - _player.transform.position.x);
        _animator.SetFloat(AnimatorNames.ENEMYDISTANCEFROMPLAYER, distanceFromPlayer);
        if(_rb.transform.position.x - _player.transform.position.x > 0 && _rb.transform.localScale.x>0)
        {
            _rb.transform.localScale = new Vector3(-_rb.transform.localScale.x, _rb.transform.localScale.y, _rb.transform.localScale.z);
        }
        else if (_rb.transform.position.x - _player.transform.position.x < 0 && _rb.transform.localScale.x < 0)
        {
            _rb.transform.localScale = new Vector3(-_rb.transform.localScale.x, _rb.transform.localScale.y, _rb.transform.localScale.z);
        }
    }

    private void TakeDamage()
    {
        if(HP > 0 && !(_isDying || _damageOnCooldown))
        {
            StartCoroutine(TakeDamageEnme(_takeDamageCooldown));
            HP--;
        } 
        else if(HP == 0 && !(_isDying || _damageOnCooldown))
        {
            StartCoroutine(Die());
        }
        
    }

    private IEnumerator Die()
    {
        _isDying= true;
        _animator.SetTrigger(AnimatorNames.ENEMYDIE);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    private IEnumerator TakeDamageEnme(float cooldown)
    {
        _damageOnCooldown = true;
        _animator.SetTrigger(AnimatorNames.ENEMYTAKEDAMAGE);
        yield return new WaitForSeconds(cooldown);
        _damageOnCooldown = false;
    }

    private void OnEnable()
    {
        GameEvents.onEnemyTakeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        GameEvents.onEnemyTakeDamage -= TakeDamage;
    }


}
