using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovementScript : MonoBehaviour
{
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float _verticalDirection = Input.GetAxis(ButtonNames.VerticalAxis);
        _rb.velocity = new Vector2(_verticalDirection*300, _rb.velocity.y);    

    }
}
