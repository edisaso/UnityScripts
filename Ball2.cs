using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball2 : MonoBehaviour
{
    public Transform target;
    public float force;
    public Slider forceSlider;
    public TMPro.TextMeshProUGUI scoreText;
    public Transform startingPosition;
    public float resetDelay = 1f;
    public float timeLimit = 7f;
    private Vector3 startPosition;
    private Rigidbody rb;
    private int score;
    private float airTime;

    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        score = 0;
        airTime = 0f;
    }

    private void Update()
    {
        // Increase the force when space bar is held down
        if (Input.GetKey(KeyCode.Space))
        {
            force += Time.deltaTime * 10f;
            forceSlider.value = force;
        }

        // Shoot the ball when space bar is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
        }

        // Check if the ball has been in the air for more than the time limit
        if (rb.velocity.magnitude > 0.1f)
        {
            airTime += Time.deltaTime;
            if (airTime > timeLimit)
            {
                ResetBall();
            }
        }
        else
        {
            airTime = 0f;
        }
    }

    private void Shoot()
    {
        Vector3 shootDirection = (target.position - transform.position).normalized;
        rb.AddForce(shootDirection * force, ForceMode.Impulse);
        force = 0f;
        forceSlider.value = 0f;
    }

    private IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(resetDelay);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            StartCoroutine(ResetPosition());
        }
    }

    private void ResetBall()
    {
        StartCoroutine(ResetPosition());
        airTime = 0f;
    }
}
