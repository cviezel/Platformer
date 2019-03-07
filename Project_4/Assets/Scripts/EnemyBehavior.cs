using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ness;
    public GameObject bullet;
    public SpriteRenderer sr;
    public AudioSource death_sound;
    public Button punchButton;
    void hit()
    {
      float x = this.transform.position.x;
      float nessX = ness.transform.position.x;
      if(Mathf.Abs(x - nessX) <= 0.5)
      {
        GameObject.Find("ness_1").GetComponent<Ness>().totalEnemies--;
        GameObject.Find("ness_1").GetComponent<Ness>().enemyCount--;
        death_sound.Play();
        Destroy(gameObject);
      }
    }
    void Start()
    {
      sr = GetComponent<SpriteRenderer>();
      punchButton.onClick.AddListener(hit);
    }
    // Update is called once per frame
    void Update()
    {
      if (GameObject.Find("ness_1").GetComponent<Ness>().gameFlag == false)
      {
        Destroy(gameObject);
      }
      float x = this.transform.position.x;
      float nessX = ness.transform.position.x;
      if (Input.GetKey(KeyCode.UpArrow))
      {
        hit();
      }
      if(x <= nessX)
      {
        sr.flipX = false;
      }
      else
      {
        sr.flipX = true;
      }
      int r = Random.Range(-200, 200);
      {
        if(r == 0)
        {
          fire();
        }
      }
    }
    void fire()
    {
      if(sr.flipX) //facing left
      {
        GameObject.Find("Bullet").GetComponent<Bullet>().x = -2f;
      }
      else
      {
        GameObject.Find("Bullet").GetComponent<Bullet>().x = 2f;
      }
      Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
