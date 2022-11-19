using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private float moveHorizontal;
    [SerializeField] private float moveVertical;

    [SerializeField] private bool moveSmooth = false;
    [SerializeField] private bool freeze = false;

    private new Transform transform;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (moveSmooth)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
        else
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
        }


    }


    void FixedUpdate()
    {
        if (transform != null && !freeze)
        {
            var pos = transform.position;
            Vector3 movementVector = new Vector2(moveHorizontal, moveVertical) * moveSpeed;

            pos += movementVector;
            transform.position = pos;
        }
    }

    /*
    private IEnumerator testFreeze()
    {
        while (true)
        {
            setFreeze();
            Debug.Log("freezed");

            yield return new WaitForSeconds(2);
            setUnFreeze();

        }
    }*/


    //freezowanie Playera
    void setFreeze()
    {
        freeze = true;
    }

    void setUnFreeze()
    {
        freeze = false;
    }
}
