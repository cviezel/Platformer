using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject ness;
    // Start is called before the first frame update
    bool moveFlag = false;
    public Animator anim;
    void Start()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
      moveFlag = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
      moveFlag = false;
      Debug.Log("stopping");
      anim.SetFloat("Speed", 0);
    }
    // Update is called once per frame
    void Update()
    {
      if(moveFlag && GameObject.Find("ness_1").GetComponent<Ness>().gameFlag)
      {
        Debug.Log("moving");
        ness.GetComponent<Ness>().moveRight();
      }
    }
}
