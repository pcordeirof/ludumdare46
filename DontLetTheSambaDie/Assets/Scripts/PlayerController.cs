using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    public int lifes;
    public Rigidbody rb;
    float horizontal;
    float vertical;
    Vector3 direction;
    public float speed = 10f;

    public Light[] lights;
    public LightManager lightManager;
    public bool entered = false;
    int indexLight;
    public List<int> lighted = new List<int>();
    public int lifesScore = 5;
    IEnumerator couroutine;

    public int score = 0;
    void Start()
    {
        lifes = 1;
    }

    // Update is called once per frame
    void Update()
    {  
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0, vertical);
        testLight();
    }

    void FixedUpdate() 
    {
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);   
        Debug.Log(entered);
     
        
    }

    void testLight()
    {
        if(Input.GetButtonDown("Submit"))
        {
            //Debug.Log("foi!");
            //couroutine = buttonDelay(0.001f);
            //StartCoroutine(couroutine); 
            Debug.Log("botão apertado!");
            if(entered == true)
            {
                GameObject.Find("LightManager").GetComponent<LightManager>().LightsOn(0.1f, indexLight);
                lighted.Add(indexLight);
                GameObject.Find("AudioManager").GetComponent<AudioManager>().Play(indexLight+6);
                //Debug.Log(indexLight);
            }
        testSequence();  
        }
    }
    
    void testSequence()
    {
        if(lighted.Count == GameObject.Find("LightManager").GetComponent<LightManager>().lighted.Count && lighted.Count != 0)
        {
            if(lighted.SequenceEqual(GameObject.Find("LightManager").GetComponent<LightManager>().lighted))
            {   
                Debug.Log("Mudou!");
                GameObject.Find("LightManager").GetComponent<LightManager>().startNewSequence();
                lighted.Clear();
                score++;
            }
            else
            {
                FindObjectOfType<AudioManager>().Stop(lifes);
                //Debug.Log("YOU LOSE!!");
                //Debug.Log("Mudou!");
                GameObject.Find("LightManager").GetComponent<LightManager>().startNewSequence();
                lighted.Clear();
                lifes++;
                lifesScore--;
                GameObject.Find("AudioManager").GetComponent<AudioManager>().Play("erro");
            }
        }
    }

    void OnTriggerStay(Collider other)
    {   
        entered = true;
        indexLight = System.Array.IndexOf(lights, other.gameObject.GetComponent<Light>());
        //Debug.Log("entered");
        
    }

    void OnTriggerExit(Collider other)
    {
        
        entered = false;    
    }
     

    IEnumerator buttonDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("botão apertado!");
        if(entered == true)
        {
            GameObject.Find("LightManager").GetComponent<LightManager>().LightsOn(0.1f, indexLight);
            lighted.Add(indexLight);
            Debug.Log(indexLight);
        }
        testSequence();
    }
    
}
