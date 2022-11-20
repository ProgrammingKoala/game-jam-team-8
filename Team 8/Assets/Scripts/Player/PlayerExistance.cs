using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerExistance : MonoBehaviour
{
    
    private Animator _animator;
    
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
            StartCoroutine(TakeDamageEnme(GameStatics.takeDamageCooldown));
            GameStatics.playerCurrentHealth = currentHP;
            Debug.Log(GameStatics.playerCurrentHealth);
        }
        CheckIfDying();     
    }

    private void CheckIfDying()
    {
        if (GameStatics.playerCurrentHealth <= 0)
        {
            StartCoroutine(Die());
        }    
    }

    private IEnumerator Die()
    {
        _isDying = true;
        _animator.SetTrigger(AnimatorNames.PLAYERDIE);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneConsts.GAMEOVER);
    }

    private IEnumerator TakeDamageEnme(float cooldown)
    {
        _damageOnCooldown = true;
        _animator.SetTrigger(AnimatorNames.PLAYERTAKEDAMAGE);
        currentHP -= 10;
        yield return new WaitForSeconds(3);
        _damageOnCooldown = false;
    }

    private void OnEnable()
    {
        GameEvents.onPlayerTakeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        GameEvents.onPlayerTakeDamage -= TakeDamage;
    }
}
