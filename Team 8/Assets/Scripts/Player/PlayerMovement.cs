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
    private Animator _animator;


    void Start()
    {
        //rigidbody = GetComponent<Rigidbody2D>();
    
        transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        GameStatics.playerPosition = transform;
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
            Flip();
        }
        else if (moveHorizontal > 0)
        {
            isFacingRight = true;
            Flip();
        }

        //poruszanie Playera
        if (transform != null && !freeze)
        {
            var pos = transform.position;
            Vector3 movementVector = new Vector2(moveHorizontal, moveVertical) * moveSpeed;
            _animator.SetFloat(AnimatorNames.PLAYERSPEED, Mathf.Abs( moveHorizontal * moveSpeed));
            pos += movementVector;
            transform.position = pos;
        }
        
    }
    
    //odwracanie Playera
    void Flip()
    {
        if (!isFacingRight)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
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
    public void SetFreeze()
    {
        freeze = true;
    }

    public void SetUnFreeze()
    {
        freeze = false;
    }
}
