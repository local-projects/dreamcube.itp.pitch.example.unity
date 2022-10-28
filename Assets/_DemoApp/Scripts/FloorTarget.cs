using TMPro;
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
<<<<<<< Updated upstream
            Hit();
=======
        {
            AudioSource.volume = 1f;
            Transform ballTransform = other.transform;
            float ballY = ballTransform.position.y;
            Debug.Log("ballY"+ballY);
            //AudioSource.pitch = 0.3f + ballY;
            AudioSource.pitch = (Random.Range(0.3f,1.2f));
            Debug.Log("pitch"+AudioSource.pitch);
        }
    }*/

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            AudioSource.volume = 1f;
            Transform ballTransform = other.transform;
            float ballY = ballTransform.position.y;
            AudioSource.pitch = 0.3f + 0.3f * ballY;
            //AudioSource.pitch = (Random.Range(1, 10));
            //Debug.Log(AudioSource.pitch);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            AudioSource.volume = 0;
        }
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
=======

    private void Update()
    {
        //Debug.Log(AudioSource.pitch);
    }
>>>>>>> Stashed changes
}
