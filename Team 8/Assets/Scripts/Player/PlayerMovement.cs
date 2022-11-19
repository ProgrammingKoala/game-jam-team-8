using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    // private SpriteRenderer spriteRenderer;

    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private float moveHorizontal;
    [SerializeField] private float moveVertical;
    private bool isFacingRight = true;

    [SerializeField] private bool moveSmooth = false;
    [SerializeField] private bool freeze = false;
    [SerializeField] private bool verticalMovement = false;

    private new Transform transform;


    void Start()
    {
        //rigidbody = GetComponent<Rigidbody2D>();
    
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (moveSmooth)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            if (verticalMovement)
                moveVertical = Input.GetAxis("Vertical");
        }
        else
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            if (verticalMovement) 
                moveVertical = Input.GetAxisRaw("Vertical");
        }
    }


    void FixedUpdate()
    {

        //odwracanie Playera prawo/lewo
        if (moveHorizontal < 0)
        {
            isFacingRight = false;
            flip();
        }
        else if (moveHorizontal > 0)
        {
            isFacingRight = true;
            flip();
        }

        //poruszanie Playera
        if (transform != null && !freeze)
        {
            var pos = transform.position;
            Vector3 movementVector = new Vector2(moveHorizontal, moveVertical) * moveSpeed;

            pos += movementVector;
            transform.position = pos;
        }
        
    }
    
    //odwracanie Playera
    void flip()
    {
        if (!isFacingRight)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
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
