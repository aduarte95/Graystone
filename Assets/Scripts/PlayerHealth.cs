using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth { get; set; }
    public float maxHealth { get; set; }

    public Slider health;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
        health.value = calculateSlideHealth();
        
    }

    // Update is called once per frame
    /*void Update()
    {

        if (Input.GetKeyDown(KeyCode.I)) {
            dealDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            gainLife(10);
        }

    }*/

    // Reduce the health in "damageValue" points
    public void dealDamage(float damageValue) {
        currentHealth -= damageValue;
        // if health gets negative passes to 0
        if (currentHealth < 0) {
            currentHealth = 0;
        }
        health.value = calculateSlideHealth();
    }

    // Gain "lifeValue" points of health
    public void gainLife(float lifeValue)
    {
        currentHealth += lifeValue;

        // if health gets over 100, it passes to 100
        if (currentHealth > 100) {
            currentHealth = 100;
        }
        health.value = calculateSlideHealth();
    }

    // Used to get % between 0 and 1 to use in slider value
    float calculateSlideHealth() {
        return currentHealth / maxHealth;
    }
}
