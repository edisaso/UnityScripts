using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GK : MonoBehaviour
{
    public Transform[] locations;
    private int currentLocationIndex = 0;
    private bool isMoving = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!isMoving)
            {
                isMoving = true;
                StartCoroutine(MoveToNextLocation());
            }
        }
    }

    private IEnumerator MoveToNextLocation()
    {
        Transform targetLocation = locations[currentLocationIndex];
        Vector3 startPosition = transform.position;
        float journeyLength = Vector3.Distance(startPosition, targetLocation.position);
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            float fraction = elapsedTime / 1f;
            transform.position = Vector3.Lerp(startPosition, targetLocation.position, fraction);
            yield return null;
        }

        currentLocationIndex = (currentLocationIndex + 1) % locations.Length;
        isMoving = false;
    }
}
