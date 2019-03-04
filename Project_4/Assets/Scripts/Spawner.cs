using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject ness;
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
        x = Random.Range(-5f, 5f);
        spawnLoc = new Vector2(x, transform.position.y);

        if(GameObject.Find("ness_1").GetComponent<Controls>().enemyCount < 6 && GameObject.Find("ness_1").GetComponent<Controls>().totalEnemies - GameObject.Find("ness_1").GetComponent<Controls>().enemyCount > 0)
        {
          if (GameObject.Find("ness_1").GetComponent<Controls>().gameFlag == true)
          {
            Instantiate(enemy, spawnLoc, Quaternion.identity);
            GameObject.Find("ness_1").GetComponent<Controls>().enemyCount++;
          }
        }
      }
    }
}
