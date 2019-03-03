using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float x = 2f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      rb.velocity = new Vector2(x, 0);
      if((transform.position.x >= 5.3 || transform.position.x <= -5.3) && transform.position.y < 30)
      {
        Destroy(gameObject);
      }
    }
}
