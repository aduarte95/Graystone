using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoisonLevel : MonoBehaviour
{
    public float currentPoison { get; set; }
    public float maxPoison { get; set; }

    public Slider poison;
    // Start is called before the first frame update
    void Start()
    {
        maxPoison = 3f;
        currentPoison = 0;
        poison.value = calculateSlidePoison();

    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKeyDown(KeyCode.Y))
        {
            losePoison(1);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            getPoison(1);
        }*/

    }

    // Reduce the poison poisonPoints
    public void losePoison(float poisonPoints)
    {
        currentPoison -= poisonPoints;
        // if poison level gets negative passes to 0
        if (currentPoison < 0)
        {
            currentPoison = 0;
        }
        poison.value = calculateSlidePoison();
    }

    // Gain poisonPoints of poison level
    public void getPoison(float poisonPoints)
    {
        currentPoison += poisonPoints;

        // if poison level gets over 3, it passes to 3
        if (currentPoison > 3)
        {
            currentPoison = 3;
        }
        poison.value = calculateSlidePoison();
    }

    // Used to get % between 0 and 1 to use in slider value
    float calculateSlidePoison()
    {
        return currentPoison / maxPoison;
    }
}
