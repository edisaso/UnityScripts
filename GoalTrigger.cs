using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public int score = 0;
    public TMPro.TextMeshProUGUI scoreText;
    public Transform startingPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            other.transform.position = startingPosition.position;
        }
    }
}
