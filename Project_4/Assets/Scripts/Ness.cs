using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Ness : MonoBehaviour {
  public Rigidbody2D rb;
  public float movespeed;
  public SpriteRenderer sr;
  public Animator anim;
  public AudioSource a1;
  public AudioSource a2;
  public AudioSource a3;
  public AudioSource bossMusic;
  public AudioSource punch;
  public AudioSource bulletHit;
  public AudioSource shieldSound;
  public int enemyCount = 0;
  public int totalEnemies = 30;
  public int health = 100;
  public bool gameFlag = true;
  public Text health_text;
  public Text enemiesLeft;
  public Text wl;
  public Button shieldButton;
  public Button punchButton;
  public bool firstRoundFlag = true;
  public double leftBound = -5.21;
  public double rightBound = 5.36;
  public bool secondRoundFlag = false;
  public Button restart;

  void Start ()
  {
    //shieldButton.onClick.AddListener(shield);
    punchButton.onClick.AddListener(hit);
    restart.onClick.AddListener(resetGame);
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    sr = GetComponent<SpriteRenderer>();
    wl.text = "";
  }
  void resetGame()
  {
    SceneManager.LoadScene("SampleScene");
  }
  void shield()
  {
    anim.SetBool("Guard", true);
    if(!shieldSound.isPlaying)
    shieldSound.Play();
  }
  void hit()
  {
    punch.Play();
    anim.SetTrigger("Hit");
  }
  public void moveLeft()
  {
    sr.flipX = true;
    if(anim.GetBool("Guard") == false)
    {
      anim.SetFloat("Speed", 0.2f);
      Vector3 position = this.transform.position;
      if(position.x >= leftBound)
      {
        position.x -= movespeed;
        this.transform.position = position;
      }
    }
  }
  public void moveRight()
  {
    sr.flipX = false;
    if(anim.GetBool("Guard") == false)
    {
      anim.SetFloat("Speed", 0.2f);
      Vector3 position = this.transform.position;
      if(position.x <= rightBound)
      {
        position.x += movespeed;
        this.transform.position = position;
      }
    }
  }
  public void winGame()
  {
    //win game
    sr.flipX = false;
    a1.Stop();
    bossMusic.Stop();
    a2.Play();
    gameFlag = false;
    Vector3 position = this.transform.position;
    position.x = -19.87f;
    position.y = -1.88f;
    this.transform.position = position;
    wl.text = "You Win!";
    anim.SetTrigger("Win");
    enemiesLeft.text = "";
    health_text.text = "";
    Destroy(shieldButton.gameObject);
    Destroy(punchButton.gameObject);
  }
  void loseGame()
  {
    anim.SetTrigger("Death");
    wl.text = "You Lose!";
    gameFlag = false; //game over
    a1.Stop();
    bossMusic.Stop();
    a3.Play();
    enemiesLeft.text = "";
    health_text.text = "";
    Destroy(shieldButton.gameObject);
    Destroy(punchButton.gameObject);
  }
  void secondRound()
  {
    health = 100;
    enemiesLeft.text = "";
    //Destroy(shieldButton.gameObject);
    //Destroy(punchButton.gameObject);
    secondRoundFlag = true;
    Destroy(shieldButton.gameObject);
    Destroy(punchButton.gameObject);
    leftBound = 14;
  }
  void secondRoundInit()
  {
    firstRoundFlag = false;
    rightBound = 21;
  }
  void Update ()
  {
    if(gameFlag)
    {
      if(transform.position.x > 5.74 && transform.position.x <= 11 && a1.isPlaying)
      {
        leftBound = 5.74;
        a1.Stop();
      }
      if(transform.position.x > 11 && health > 0 && gameFlag && !bossMusic.isPlaying)
      {
        bossMusic.Play();
        leftBound = 11;
        secondRound();
      }
      //keyboard controls for testings
      if (Input.GetKey(KeyCode.DownArrow))
      {
        if(anim.GetBool("Guard") == false)
          shield();
        else
          anim.SetBool("Guard", false);
      }
      if (Input.GetKey(KeyCode.UpArrow))
      {
        hit();
      }
      if (Input.GetKey(KeyCode.RightArrow))
      {
        moveRight();
      }
      if (Input.GetKey(KeyCode.LeftArrow))
      {
        moveLeft();
      }
      health_text.text = "Health: " + health.ToString();
      if(firstRoundFlag)
      {
        enemiesLeft.text = "Enemies: " + totalEnemies.ToString();
      }
      if(totalEnemies == 0 && firstRoundFlag)
      {
        secondRoundInit();
      }
      if (Input.GetKey(KeyCode.Space))
      {
        winGame();
      }
    }
  }
  void hitWithBullet()
  {
    bulletHit.Play();
    health -=10;
  }
  void OnCollisionEnter2D (Collision2D col)
  {
    if(col.gameObject.tag.Equals("Bullet") || col.gameObject.tag.Equals("Meteor"))
    {
      //Debug.Log("Ness: " + transform.position.x);
      //Debug.Log("Bullet: " + col.gameObject.transform.position.x);
      float nessX = transform.position.x;
      float bulletX = col.gameObject.transform.position.x;
      if(anim.GetBool("Guard") == true)
      {
        if((bulletX - nessX) > 0) //bullet hits from right
        {
          if(sr.flipX == true) //facing left
          {
            hitWithBullet();
          }
        }
        else //bullet hits from left
        {
          if(sr.flipX == false)//facing right
          {
            hitWithBullet();
          }
        }
      }
      else
      {
        hitWithBullet();
      }
      Destroy(col.gameObject);
    }
    if(health <= 0)
    {
      loseGame();
    }
  }
}
