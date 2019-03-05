using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  // Start is called before the first frame update
  public GameObject enemy;
  public GameObject ness;
  public GameObject bullet;
  float x;
  Vector2 spawnLoc;
  float spawnRate = 2;
  float nextSpawn = 0;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

    if(Time.time > nextSpawn)
    {
      nextSpawn = Time.time + spawnRate;
      if (GameObject.Find("ness_1").GetComponent<Ness>().gameFlag == true)
      {
        if(GameObject.Find("ness_1").GetComponent<Ness>().firstRoundFlag == false)
        {
          spawnLoc = new Vector2(-5, transform.position.y);
          GameObject.Find("Bullet").GetComponent<Bullet>().x = 1f;
          Instantiate(bullet, spawnLoc, Quaternion.identity);
        }
        x = Random.Range(-5f, 5f);
        spawnLoc = new Vector2(x, transform.position.y);
        if(GameObject.Find("ness_1").GetComponent<Ness>().enemyCount < 10 && GameObject.Find("ness_1").GetComponent<Ness>().totalEnemies - GameObject.Find("ness_1").GetComponent<Ness>().enemyCount > 0)
        {
          Instantiate(enemy, spawnLoc, Quaternion.identity);
          GameObject.Find("ness_1").GetComponent<Ness>().enemyCount++;
        }
      }
    }
  }
}
