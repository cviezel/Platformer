using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
  public GameObject ness;
  public GameObject meteor;
  public AudioSource boom;
  float x;
  Vector2 spawnLoc;
  public float spawnRate;
  float nextSpawn = 0;
  Ness n;
  int t = 0;
  // Start is called before the first frame update
  void Start()
  {
    n = GameObject.Find("ness_1").GetComponent<Ness>();
  }
  // Update is called once per frame
  void Update()
  {
    if(n.gameFlag && n.secondRoundFlag && t == 0)
    {
      t = (int)Time.time;
    }
    //Debug.Log(Time.time + " " + t);
    if(n.gameFlag && n.secondRoundFlag)
    {
      n.enemiesLeft.text = "Time Left: " + (60 - ((int)Time.time - t));
      if(Time.time > nextSpawn)
      {
        nextSpawn = Time.time + spawnRate;
        for(int i = 0; i < 4; i++)
        {
          x = Random.Range((float)n.leftBound, (float)n.rightBound);
          spawnLoc = new Vector2(x, 5);
          Instantiate(meteor, spawnLoc, Quaternion.identity);
        }
      }
      //Debug.Log(Time.time);
      if(((int)Time.time - t) >= 60)
      {
        n.winGame();
      }
    }
  }
}
