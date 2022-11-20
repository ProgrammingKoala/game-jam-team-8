using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerExistance : MonoBehaviour
{
    
    private Animator _animator;
    
    [SerializeField] int HP;
    [SerializeField] private float _takeDamageCooldown;
    private bool _damageOnCooldown;
    private bool _isDying;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        
        _isDying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TakeDamage()
    {
        if (HP > 0 && !(_isDying || _damageOnCooldown))
        {
            StartCoroutine(TakeDamageEnme(_takeDamageCooldown));
            HP--;
        }
        else if (HP == 0 && !(_isDying || _damageOnCooldown))
        {
            StartCoroutine(Die());
        }

    }

    private IEnumerator Die()
    {
        _isDying = true;
        _animator.SetTrigger(AnimatorNames.PLAYERDIE);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneConsts.MENU);
    }

    private IEnumerator TakeDamageEnme(float cooldown)
    {
        _damageOnCooldown = true;
        _animator.SetTrigger(AnimatorNames.PLAYERTAKEDAMAGE);
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
