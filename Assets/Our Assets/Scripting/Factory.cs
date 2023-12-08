using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{

    int health;
    int energy;
    bool isLive = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Factory Start");
    }

    public int healthChange(int value)
    {
        health += value;
        if (health < 0)
        {
            isLive = false;
        }
        return health;
    }

    public int energyChange(int value)
    {
        energy += value;
        if (energy < 0)
        {
            isLive = false;
        }
        return energy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
