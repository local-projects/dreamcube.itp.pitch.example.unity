using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLightActivator : MonoBehaviour
{
    private bool _cachedValue = true;

    private void OnEnable()
    {
        GameObject ballObject = GameObject.FindGameObjectWithTag("Ball");
        var light = ballObject.GetComponent<Light>();

        if ( light != null)
        {
            _cachedValue = light.enabled;
            light.enabled = true;
        }
    }

    private void OnDisable()
    {
        GameObject ballObject = GameObject.FindGameObjectWithTag("Ball");
        if (ballObject != null)
            ballObject.GetComponent<Light>().enabled = _cachedValue;
    }
}
