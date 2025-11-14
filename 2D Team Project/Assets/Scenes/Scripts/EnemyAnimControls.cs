using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimControls : MonoBehaviour
{
    Animator animator;
    SpriteRenderer SPR;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        SPR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = GetComponent<Rigidbody2D>().velocity.x;
        animator.SetFloat("x", moveX);
        if (moveX > 0)
        {
            //we're moving to the left
            //flip our sprite
            SPR.flipX = true;
        }
        else if (moveX < 0)
        {
            SPR.flipX = false;
        }
    }
}