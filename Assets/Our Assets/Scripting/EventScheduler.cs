using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This file is used to pop up next events based on preset logic: strings pearls or desicion tree



public class EventScheduler : MonoBehaviour
{

    [SerializeField]
    Narrative narrative;

    int curInScene = 0;
    //how many target random event we allow in each scene
    List<int> targetInScene = new List<int>();
    




    // Start is called before the first frame update
    void Start()
    {
        int targetScene1 = 4;
        int targetScene2 = 5;
        int targetScene3 = 2;
        targetInScene.Add(targetScene1);
        targetInScene.Add(targetScene2);
        targetInScene.Add(targetScene3);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetCurInScene()
    {
        curInScene = 0;
    }

    private Event generateRandomEvent(int scene)
    {
        List<Event> lists = narrative.getEventsAtScene(scene);
        int count = lists.Count;
        int random = Random.Range(0, count - 1);
        Event res = lists[random];
        lists.RemoveAt(random);
        return res;
    }

    public void resetCurEvent()
    {
        curInScene = 0;
        Debug.Log("event reset");
    }


    // scene is 0,1,2
    public Event getNextEvent(int scene)
    {
        if(scene == 0 && curInScene == 0)
        {
            curInScene++;
            return narrative.getScene1Start();
            
        }
        else if(scene == 1)
        {
            if (curInScene == 0)
            {
                curInScene++;
                return narrative.getScene2Start();
            }
            else if(curInScene == targetInScene[1] - 1)
            {
                curInScene++;
                return narrative.getScene2End();
            }
        } else if(scene == 2)
        {
            if (curInScene == 0)
            {
                curInScene++;
                return narrative.getScene3Start();
            }
            else if (curInScene == 1)
            {
                curInScene++;
                return narrative.getScene2End();
            }
 
        }

        if (curInScene >= targetInScene[scene])
            return null;
        Event res = generateRandomEvent(scene);
        if (res != null)
        {
            curInScene++;
            return res;
        }
        return null;
    }

}
