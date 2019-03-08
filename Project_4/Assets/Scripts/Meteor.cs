using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject ness;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position.y);
        if(transform.position.y <= -1 && transform.position.x < 50)
        {
          Destroy(gameObject);
          //Debug.Log("destroying this");
        }
    }
}
