using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This file is used to record the world settings. 

public class World : MonoBehaviour
{

    int scene = 0;
    float distance = 0;
    float speed = 8;
    int sceneLength = 1644; //scene length - Mech width in pixels
    bool mechWalking = false;
    public GameObject background;
    public GameObject mech;
    public GameObject [] meters;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (mechWalking){
            moveObjects();
            for (int i = 0; i < meters.Length; i++){
                meters[i].GetComponent<manageMeters>().tick();
            }
        }
        if(distance >= sceneLength){ //this code will assume scene is tied to locations and not unity scenes
            /*if(scene < 2){
                scene++;
                distance = 0;
                //change background to scene
                positionObjects();
            } else {
                //end event
            }
            */
        } /*else if (check if opening an event){
            //open event
        }
        */
    }

    void moveObjects (){

        distance+=speed*Time.deltaTime;

        positionObjects();
    }

    public void setMechWalking(bool mechWalking)
    {
        this.mechWalking = mechWalking;
    }

    void positionObjects(){
        mech.transform.position = new Vector3 (distance, mech.transform.position.y , mech.transform.position.z);
        background.transform.position = new Vector3 (-distance*((1844-940)/sceneLength), background.transform.position.y , background.transform.position.z);
    }
}
