using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Transform target;
    public float force;
    public Slider forceSlider;
    private Vector3 startPosition;
    private Rigidbody rb;

    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
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
    }

    private void Shoot()
    {
        Vector3 shootDirection = (target.position - transform.position).normalized;
        rb.AddForce(shootDirection * force, ForceMode.Impulse);
        force = 0f;
        forceSlider.value = 0f;

        // Start the coroutine to reset the ball position after 10 seconds
        StartCoroutine(ResetPosition(10f));
    }

    private IEnumerator ResetPosition(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
    }
}