using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockbackFeedback : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _strength = 16, delay = 0.15f;
    public UnityEvent OnBegin, OnDone;

    public void PlayFeedback(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        _rb.AddForce(direction * _strength, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        //Debug.Log(_rb.velocity);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Jebac");
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = 0f;
        //Debug.Log(_rb.velocity);
        OnDone?.Invoke();
    }
}
