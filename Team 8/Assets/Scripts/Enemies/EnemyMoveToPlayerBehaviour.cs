using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToPlayerBehaviour : StateMachineBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    private GameObject _player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb = animator.GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float xDirection = (animator.transform.position.x - _player.transform.position.x) < 0 ? 1 : -1;
        _rb.velocity = new Vector2(xDirection * _speed, 0);
        animator.SetFloat("distanceFromPlayer", Mathf.Abs(animator.transform.position.x - _player.transform.position.x));
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb.velocity = new Vector2(0 , 0);
    }
}
