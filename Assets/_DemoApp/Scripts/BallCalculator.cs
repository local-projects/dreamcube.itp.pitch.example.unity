using System;
using UnityEngine;
using dreamcube.unity.Core.Scripts.Signals.Events;
using dreamcube.unity.Core.Scripts.Util;

public class BallCalculator : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 impulse;

    private Vector3 _lastPosition;
    private Vector3 _lastVelocity;

    private void Start()
    {
        _lastPosition = transform.position;
        _lastVelocity = Vector3.zero;
    }

    public void OnEnable()
    {
        EventManager.Instance.StartListening(EventStrings.EventOnAllScenesLoaded, EventHandler);
    }

    public void OnDisable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.StopListening(EventStrings.EventOnAllScenesLoaded, EventHandler);
        }
    }

    private void EventHandler(string theEvent, string msg, GameObject sender)
    {
        if (theEvent == EventStrings.EventOnAllScenesLoaded)
        {
        }
    }



    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        velocity = (pos - _lastPosition) / Time.deltaTime;
        impulse = (velocity - _lastVelocity);

        _lastPosition = pos;
        _lastVelocity = velocity;

        UpdateUI();
    }

    private float _maxSpeed = 0f;
    private float _maxImpulse = 0f;
    private void UpdateUI()
    {
        //speed 
        float speed = Math.Abs(velocity.magnitude);

        if (speed > _maxSpeed)
        {
            _maxSpeed = speed;
        }
        
        //observed max speed was nearly 12, so max out the slider at around 14-15
        float normalizedSpeed = Extensions.mapRange(0, 15, 0, 1, speed);

        //impulse
        float impulseMag = Math.Abs(impulse.magnitude);
        if (impulseMag > _maxImpulse)
        {
            _maxImpulse = impulseMag;
        }

        float normalizedImpulse = Extensions.mapRange(0, 15, 0, 1, impulseMag);

    }
}
