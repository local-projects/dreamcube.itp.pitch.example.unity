using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using dreamcube.unity.Core.Scripts.Signals.Events;

public class AudioFeedback : MonoBehaviour
{

    public List<string> eventStrings;
    public List<AudioClip> audioClips;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void OnEnable()
    {
        if (eventStrings.Count == audioClips.Count)
        {
            foreach (var s in eventStrings)
            {
                EventManager.Instance.StartListening(s, EventHandler);
            }
        }
    }

    public void OnDisable()
    {
        if (eventStrings.Count == audioClips.Count)
        {

            foreach (var s in eventStrings)
            {
                if (EventManager.Instance != null)
                {
                    EventManager.Instance.StopListening(s, EventHandler);
                }
            }
        }
    }

    private void EventHandler(string theEvent, string msg, GameObject sender)
    {
        //Log.Debug("event handled");
        if (eventStrings.Count == audioClips.Count)
        {
            for (int i = 0; i < eventStrings.Count; i++)
            {
                if (theEvent == eventStrings[i])
                {
                    //Log.Debug("playing one shot");
                    _audioSource.PlayOneShot(audioClips[i]);
                }
            }
        }
    }
}
