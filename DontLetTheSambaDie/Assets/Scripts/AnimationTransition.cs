using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTransition : MonoBehaviour
{
    public Animator animator;


    void Update()
    {
        if(Input.GetButton("Submit"))
        {
            animator.SetBool("ButtonDown", true);
        }
        else
        {
            animator.SetBool("ButtonDown", false);
        }

        if(Input.GetButtonDown("Submit"))
        {
            if(!GameObject.Find("PlayerController").GetComponent<PlayerController>().entered)
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("tata");
            }
        }
    }
}
