using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This file is used to pop up next events based on preset logic: strings pearls or desicion tree


public class EventScheduler : MonoBehaviour
{

    Narrative narrative;

    // Start is called before the first frame update
    void Start()
    {

        narrative = GetComponent<Narrative>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
