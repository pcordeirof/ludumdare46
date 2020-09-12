using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public Light[] lights;
    public List<int> lighted = new List<int>();
    private IEnumerator coroutineSeq;
    private IEnumerator coroutineOn;
    private IEnumerator coroutineOff;
    public GameObject go;
    private IEnumerator cGoOn;
    private IEnumerator cGoOff;
    public bool played = false;
    //int l = 0;
    void Start()
    {
        foreach (Light l in lights)
        {
            l.intensity = 0f;
        }

        coroutineSeq = Sequence(5.0f);
        StartCoroutine(coroutineSeq);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator Sequence(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        lighted.Add(Random.Range(0,3));
        foreach(int l in lighted)
        {
            coroutineOn = OnLight(1.0f, l);
            StartCoroutine(coroutineOn);
            yield return new WaitForSeconds(1.5f);
        }

        cGoOn = GoOn(1f);
        StartCoroutine(cGoOn);
        
        played = false;    
    }

    private IEnumerator OnLight(float waitTime, int index)
    {
        yield return new WaitForSeconds(waitTime);
        lights[index].intensity = 5f;
        coroutineOff = OffLight(1.0f, index);
        StartCoroutine(coroutineOff);
    }

    private IEnumerator OffLight(float waitTime, int index)
    {
        yield return new WaitForSeconds(waitTime);
        lights[index].intensity = 0f;
        //l++;
    }

    public void LightsOn(float waitTime,int index)
    {
        coroutineOn = OnLight(waitTime, index);
        StartCoroutine(coroutineOn);
    }

    public void startNewSequence()
    {
        coroutineSeq = Sequence(2.0f);
        StartCoroutine(coroutineSeq);
    }

    IEnumerator GoOn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        go.SetActive(true);
        cGoOff = GoOff(1.0f);
        StartCoroutine(cGoOff);
    }
       IEnumerator GoOff(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        go.SetActive(false);
    }
}
