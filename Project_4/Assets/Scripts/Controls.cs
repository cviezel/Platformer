using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {
    public Rigidbody2D rb;
    public float movespeed;
    public SpriteRenderer sr;
    public Animator anim;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    void Update () {
        anim.SetFloat("Speed", 0);
        anim.SetBool("Guard", false);
        if (Input.GetKey(KeyCode.RightArrow))
        {
          //Debug.Log(this.transform.position.x);
          sr.flipX = false;
          anim.SetFloat("Speed", 0.2f);
          Vector3 position = this.transform.position;
          if(position.x <= 5.36)
          {
            position.x += movespeed;
            this.transform.position = position;
          }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
          sr.flipX = true;
          anim.SetFloat("Speed", 0.2f);
          Vector3 position = this.transform.position;
          if(position.x >= -5.21)
          {
            position.x -= movespeed;
            this.transform.position = position;
          }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
          anim.SetTrigger("Hit");
          //anim.SetBool("Hit", false);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
          anim.SetBool("Guard", true);
          //anim.SetBool("Hit", false);
        }
    }
}
