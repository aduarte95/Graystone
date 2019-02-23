using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string name;
    
    [TextArea(3,10)]
    public string[] sentences;
    public GameObject[] diamondsMission;
    public bool Finished { get; set; } = false;
    private bool firstTime = true; //To avoid activated diamonds that other object already deactivates

    public void setDiamondsMission()
    {
        if (firstTime)
        {
            diamondsMission[0].SetActive(true);

            for (int i = 1; i < diamondsMission.Length; ++i)
            {
                diamondsMission[i].SetActive(false);
            }

            firstTime = false;
        }
    }
}
