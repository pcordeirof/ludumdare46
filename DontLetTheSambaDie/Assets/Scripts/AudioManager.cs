using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            //s.number = s.number;
        }
    }
    void Start() 
    {
        //Play("sambaCompleto");
        Play("cavaquinho");
        Play("cuica");
        Play("pandeiro");
        Play("surdo");
        Play("violao");   
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    public void Play(int number)
    {
        Sound s = Array.Find(sounds, sound => sound.number == number);
        s.source.Play();
    }

    public void Stop(int number)
    {
        Sound s = Array.Find(sounds, sound => sound.number == number);
        s.source.Stop();
    }

    public void ChangeVolume(bool pause)
    {
        if(pause)
        {
            for (int i = 0; i < 6; i++)
            {
                sounds[i].source.volume = .2f;
            }
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                sounds[i].source.volume = .8f;
            }
        }
    }

    public void playAll()
    {
        for (int i = 1; i<6; i++)
        {
          sounds[i].source.volume = .8f;
          sounds[i].source.Play();
        }
    }
}
