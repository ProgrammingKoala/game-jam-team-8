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
    private Animator _animator;
    private Rigidbody2D _rb;
 
    void Start()
    {      
        _animator = GetComponentInParent<Animator>();
        _rb= GetComponentInParent<Rigidbody2D>();
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
        _animator.SetTrigger(AnimatorNames.PLAYERATTACK);
        _attackOnCooldown = true;
        
        _isAttacking= true;
        yield return new WaitForSeconds(0.5f);
        _isAttacking = false;
        

        yield return new WaitForSeconds(seconds);

        _attackOnCooldown = false;
    }

    private IEnumerator Parry(float seconds)
    {
        _parryOnCooldown = true;
        
        GameStatics.playerIsParrying = true;
        yield return new WaitForSeconds(0.7f);
        GameStatics.playerIsParrying = false;
        

        yield return new WaitForSeconds(seconds);

        _parryOnCooldown = false;
    }

    private IEnumerator waitToAttack(float seconds, Collider2D collision)
    {
        yield return new WaitForSeconds(1);
        if(collision!= null) {
            Destroy(collision.gameObject);
        }
        _rb.velocity = Vector2.zero;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isAttacking && collision.gameObject.CompareTag("Enemy"))
        {
            // GameEvents.onEnemyTakeDamage();
            // collision.gameObject.GetComponentInChildren<SpriteRenderer>().color = Color.red;

            // //compute vector (length one) from game object's pivot to the player's pivot:
            // Vector3 hitVector = (collision.transform.position - transform.position).normalized;

            // //if you want only horizontal plane movement, disable y-component of hitVector:
            // hitVector = (collision.transform.position - transform.position);
            // hitVector.y = 0;
            // hitVector = hitVector.normalized;


            //// collision.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(hitVector * 2000);
            // collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.forward);
            

            StartCoroutine(waitToAttack(2, collision));
            
            
            
        }
    }
}
