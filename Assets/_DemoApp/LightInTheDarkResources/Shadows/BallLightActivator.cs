using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLightActivator : MonoBehaviour
{
    private bool _cachedValue = true;

    private void OnEnable()
    {
        GameObject ballObject = GameObject.FindGameObjectWithTag("Ball");
        _cachedValue = ballObject.GetComponent<Light>().enabled;
        ballObject.GetComponent<Light>().enabled = true;
    }

    private void OnDisable()
    {
        GameObject ballObject = GameObject.FindGameObjectWithTag("Ball");
        if (ballObject)
            ballObject.GetComponent<Light>().enabled = _cachedValue;
    }
}
