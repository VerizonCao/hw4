using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UserInput : MonoBehaviour
{
    [SerializeField]
    EventScheduler scheduler;

    [SerializeField]
    private GameObject context;
    [SerializeField]
    private GameObject option1;
    [SerializeField]
    private GameObject option2;
    [SerializeField]
    private GameObject backing;

    private Event currentEvent;
    private int index = 0;

    [SerializeField]
    private GameObject nextBotton;
    [SerializeField]
    private GameObject fowardButton;
    [SerializeField]
    private GameObject backwordButton;
    [SerializeField]
    private GameObject mech;   // only for the obj
    private Factory mech_real;

    [SerializeField]
    private GameObject world;
    private World world_real;

    // Start is called before the first frame update
    void Start()
    {
        mech_real = mech.GetComponent<Factory>();
        world_real = world.GetComponent<World>();
        
    }

    // Update is called once per frame
    void Update()
    {

        // click will force to next params if the text is very long.
        // right click can go back. 
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Pressed left-click.");

            //forward();
        }

        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("Pressed right-click.");
            //backward();
        }


        // event can only be progressed by click button or choose one of the dialogue.



    }

    public void updateScene(int scene)
    {
        currentEvent = null;
        backing.SetActive(false);
        clearAlltext();
        scheduler.resetCurEvent();
    }

    // Render the next UI page
    public void progress(int scene)
    {
        Event d = scheduler.getNextEvent(scene);
        // render this events on the canvas
        if (d != null)
        {
            currentEvent = d;
            index = 0;
            renderContext(0);

            //check the text count
            if (currentEvent.text.Count > 1)
            {
                //show forward and backwordf botton
                fowardButton.SetActive(true);
                backwordButton.SetActive(true);
                option1.SetActive(false);
                option2.SetActive(false);
            }
            else
            {
                fowardButton.SetActive(false);
                backwordButton.SetActive(false);
                //show the options
                option1.GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText(d.options[0]);
                option1.SetActive(true);
                if (d.options.Count > 1)
                {
                    option2.SetActive(true);
                    option2.GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText(d.options[1]);
                }
                
            }  
        }
        else
        {
            //no event, story is ending

        }

    }


    // go to the next page of the current event if has
    private void forward()
    {
        if (currentEvent == null)
        {
            return;
        }
        if (index < currentEvent.text.Count - 1)
        {
            index++;
            renderContext(0);
        }
    }

    //back to the previous page of the current event if has
    private void backward()
    {
        if (currentEvent == null)
        {
            return;
        }
        if (index > 0)
        {
            index--;
            renderContext(0);
        }
    }

    private void clearAlltext()
    {
        //currentEvent = null;
        option1.SetActive(false);
        option2.SetActive(false);
        context.SetActive(false);
        world_real.setMechWalking(true);
        //backing.SetActive(false);
    }

    private void enforceState(statChanges sc)
    {
        if (sc == null)
        {
            return;
        }
        mech_real.healthChange(sc.health);
        mech_real.energyChange(sc.energy);
        mech_real.distanceChange(sc.distance);
    }

    public void ClickOption1()
    {
        Debug.Log("option 1");
        if (currentEvent == null)
        {
            return;
        }
        enforceState(currentEvent.changes[0]);
        // now it's progress to next event
        option1.SetActive(false);
        option2.SetActive(false);
        //progress();
        clearAlltext();
        renderContext(1);
        
    }

    public void ClickOption2()
    {
        Debug.Log("option 2");
        if (currentEvent == null)
        {
            return;
        }
        enforceState(currentEvent.changes[1]);
        // now it's progress to next event
        //progress();
        clearAlltext();
        option1.SetActive(false);
        option2.SetActive(false);
        renderContext(2);
    }

    public void ClickForward()
    {
        Debug.Log("forward");
        forward();
    }

    public void ClickBackward()
    {
        Debug.Log("backward");
        backward();
    }

    public void ClickNext()
    {
        Debug.Log("next");
        //get next event or next wording(not in design yet)
        //progress();
        //hide itself

        clearAlltext();
        nextBotton.SetActive(false);
    }

    private void renderContext(int type)
    {
        TMPro.TextMeshProUGUI tmpContext = context.GetComponent<TMPro.TextMeshProUGUI>();
        if (type == 0){
            backing.transform.localScale = new Vector3 (1f,1f,1f);
            tmpContext.SetText(currentEvent.text[index]);
            //if it's at the last page of this event, show options
            if (currentEvent != null && index == currentEvent.text.Count - 1)
            {
                option1.SetActive(true);
                //show the options
                option1.GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText(currentEvent.options[0]);

                if (currentEvent.options.Count > 1)
                {
                    option2.SetActive(true);
                    option2.GetComponentInChildren<TMPro.TextMeshProUGUI>().SetText(currentEvent.options[1]);
                }

            }
            else
            {
                option1.SetActive(false);
                option2.SetActive(false);
            }
        }else{
            if (type == 1){
                tmpContext.SetText(currentEvent.results[0]);
            }else if (type == 2){
                tmpContext.SetText(currentEvent.results[1]);
            }
            backing.transform.localScale = new Vector3 (0.5f,0.7f,1f);
            option1.SetActive(false);
            option2.SetActive(false);
        } 
        context.SetActive(true);
        backing.SetActive(true);

        
    }
}
