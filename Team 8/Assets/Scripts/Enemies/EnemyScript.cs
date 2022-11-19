using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(_player == null) { _player = GameObject.FindGameObjectWithTag("Player");  }
        float distanceFromPlayer = Mathf.Abs(_rb.transform.position.x - _player.transform.position.x);
        _animator.SetFloat(AnimatorNames.ENEMYDISTANCEFROMPLAYER, distanceFromPlayer);
    }
}
