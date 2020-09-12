using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class pressStart : MonoBehaviour
{
    public Transform instance;
    public bool time = false;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
        time = true;

    }

    void Update() 
    {
        if(time)
        {
            grow();
        }
    }

    void grow()
    {
        if(instance.localScale.x < 10)
        {
            instance.localScale += new Vector3(0.1f,0.1f, 0f);
        }
        else
        {
            instance.localScale += Vector3.zero;
        }
    }

}
