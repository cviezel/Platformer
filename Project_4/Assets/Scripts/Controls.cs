using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=FFBODhX_IUM
//https://www.youtube.com/watch?v=U2Z6Onm40oA

public class Controls : MonoBehaviour {
    public Rigidbody2D rb;
    public float movespeed;
    public SpriteRenderer sr;
    public Animator anim;
    public AudioSource a1;
    public AudioSource a2;
    public AudioSource a3;
    public int enemyCount = 0;
    public int totalEnemies = 10;
    public int health = 100;
    public bool gameFlag = true;
    public Text health_text;
    public Text enemiesLeft;
    public Text wl;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        wl.text = "";
        //health_text = GetComponent<Text>();
        //enemiesLeft = GetComponent<Text>();
    }

    void Update ()
    {
      if ((Input.GetKey(KeyCode.Space) || totalEnemies == 0) && gameFlag == true)
      {
        //win game
        a1.Stop();
        a2.Play();
        gameFlag = false;
        wl.text = "You Win!";
        anim.SetTrigger("Win");
      }
      if(gameFlag)
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
      health_text.text = "Health: " + health.ToString();
      enemiesLeft.text = "Enemies: " + totalEnemies.ToString();
    }
    void OnCollisionEnter2D (Collision2D col)
    {
      if(col.gameObject.tag.Equals("Bullet"))
      {
        if(anim.GetBool("Guard") == true)
        {
          Destroy(col.gameObject);
        }
        else
        {
          health-=10;
          Destroy(col.gameObject);
        }
      }
      if(health <= 0)
      {
        anim.SetTrigger("Death");
        wl.text = "You Lose!";
        gameFlag = false; //game over
        a1.Stop();
        a3.Play();
      }
    }
}
