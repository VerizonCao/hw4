using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{

    int health;
    int energy;
    bool isLive = true;
    int distance;

    [SerializeField]
    private manageMeters meterHealth;

    [SerializeField]
    private manageMeters meterEnergy;

    [SerializeField]
    private World world;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Factory Start");
    }

    public int healthChange(int value)
    {
        meterHealth.value += value;
        if (health < 0)
        {
            isLive = false;
        }
        return health;
    }

    public int energyChange(int value)
    {
        meterEnergy.value += value;
        if (energy < 0)
        {
            isLive = false;
        }
        return energy;
    }

    public int distanceChange(int value)
    {
        world.changeDistance(value);
        return distance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
