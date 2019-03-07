using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class shieldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public AudioSource shieldSound;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnPointerDown(PointerEventData eventData)
    {
      anim.SetBool("Guard", true);
      if(!shieldSound.isPlaying)
      shieldSound.Play();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
      anim.SetBool("Guard", false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
