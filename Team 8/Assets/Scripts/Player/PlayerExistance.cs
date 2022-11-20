using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerExistance : MonoBehaviour
{
    
    private Animator _animator;
    
    [SerializeField] float _takeDamageCooldown;
    private static int currentHP;
    private bool _damageOnCooldown;
    private bool _isDying;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        currentHP = GameStatics.playerMaxHealth;
        _isDying = false;
    }

    private void TakeDamage()
    {
        if (currentHP > 0 && !(_isDying || _damageOnCooldown))
        {
            StartCoroutine(TakeDamageEnme(_takeDamageCooldown));
            currentHP -= 25;
            GameStatics.playerCurrentHealth = currentHP;
        }
        else if (currentHP == 0 && !(_isDying || _damageOnCooldown))
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
