using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoxes : MonoBehaviour
{
    public GameObject boxPrefab;
    public Transform spawnArea;
    public int maxBoxes = 10;

    private List<GameObject> boxes = new List<GameObject>();
    private int numBoxesSpawned = 0;
    private int boxesToSpawn = 2;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (numBoxesSpawned >= maxBoxes)
            {
                // Destroy all boxes
                foreach (GameObject box in boxes)
                {
                    Destroy(box);
                }
                boxes.Clear();

                // Increase number of boxes to spawn
                boxesToSpawn++;
                if (boxesToSpawn > 5)
                {
                    boxesToSpawn = 5;
                }

                // Reset number of boxes spawned
                numBoxesSpawned = 0;
            }

            // Spawn new boxes
            for (int i = 0; i < boxesToSpawn; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2f, spawnArea.position.x + spawnArea.localScale.x / 2f),
                                               Random.Range(spawnArea.position.y - spawnArea.localScale.y / 2f, spawnArea.position.y + spawnArea.localScale.y / 2f),
                                               Random.Range(spawnArea.position.z - spawnArea.localScale.z / 2f, spawnArea.position.z + spawnArea.localScale.z / 2f));
                GameObject box = Instantiate(boxPrefab, spawnPos, Quaternion.identity);
                boxes.Add(box);
            }

            numBoxesSpawned += boxesToSpawn;
        }
    }
}
