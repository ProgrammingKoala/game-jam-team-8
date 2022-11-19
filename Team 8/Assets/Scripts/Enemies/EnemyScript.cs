using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    [SerializeField] private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Mathf.Abs(_player.transform.position.x - _rb.transform.position.x);
        _animator.SetFloat(AnimatorNames.ENEMYDISTANCEFROMPLAYER, distanceFromPlayer);
    }
}
