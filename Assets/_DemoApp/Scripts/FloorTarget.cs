﻿using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloorTarget : MonoBehaviour
{
    [SerializeField]
    private GameObject VisualObject;
    [SerializeField]
    private TextMeshPro StepNumberText;
    [SerializeField]
    private AudioSource AudioSource;

    private int _timesHit;

    public FloorTarget(GameObject visualObject, TextMeshPro stepNumberText)
    {
        VisualObject = visualObject;
        StepNumberText = stepNumberText;
    }

    private void OnTriggerEnter(Collider other)
    {
        // only be triggered by an object tagged as "Ball"
        if (other.gameObject.CompareTag("Ball"))
            Hit();
    }

    public void Hit()
    {
        PositiveFeedback();
    }

    public void PositiveFeedback()
    {
        _timesHit++;

        // change color
        var col = Random.ColorHSV(0, 1, 0.5f, 1, 1, 1);
        VisualObject.GetComponent<MeshRenderer>().material.color = col;

        // update text
        StepNumberText.text = _timesHit.ToString("D2");

        // make a sound
        AudioSource.pitch = (Random.Range(0.6f, 1.2f));
        AudioSource.Play();
    }
}