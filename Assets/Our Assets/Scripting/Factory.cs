using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{

    int health;
    int energy;
    bool isLive = true;
    int distance;

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

    public int distanceChange(int value)
    {
        distance += value;
        return distance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
