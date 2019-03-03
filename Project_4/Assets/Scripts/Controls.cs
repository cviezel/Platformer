using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=FFBODhX_IUM
//https://www.youtube.com/watch?v=U2Z6Onm40oA

public class Controls : MonoBehaviour {
    public Rigidbody2D rb;
    public float movespeed;
    public SpriteRenderer sr;
    public Animator anim;
    public AudioSource a1;
    public AudioSource a2;
    public int enemyCount = 0;
    public int totalEnemies = 10;

    bool winFlag = false;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update () {
      if (Input.GetKey(KeyCode.Space) || totalEnemies == 0 && winFlag == false)
      {
        //win game
        a1.Stop();
        a2.Play();
        winFlag = true;
        anim.SetTrigger("Win");
      }
      if(!winFlag)
      {
        anim.SetFloat("Speed", 0);
        anim.SetBool("Guard", false);
        if (Input.GetKey(KeyCode.DownArrow))
        {
          anim.SetBool("Guard", true);
          //anim.SetBool("Hit", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
          //Debug.Log(this.transform.position.x);
          sr.flipX = false;
          if(anim.GetBool("Guard") == false)
          {
            anim.SetFloat("Speed", 0.2f);
            Vector3 position = this.transform.position;
            if(position.x <= 5.36)
            {
              position.x += movespeed;
              this.transform.position = position;
            }
          }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
          sr.flipX = true;
          if(anim.GetBool("Guard") == false)
          {
            anim.SetFloat("Speed", 0.2f);
            Vector3 position = this.transform.position;
            if(position.x >= -5.21)
            {
              position.x -= movespeed;
              this.transform.position = position;
            }
          }
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
          anim.SetTrigger("Hit");
          //anim.SetBool("Hit", false);
        }
      }
    }
}
