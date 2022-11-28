using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
        public int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;

    }
    public void PLayerTakeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
