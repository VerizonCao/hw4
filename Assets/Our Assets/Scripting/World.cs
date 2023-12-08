using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This file is used to record the world settings. 

public class World : MonoBehaviour
{

    int scene = 0;
    public float distance = 0;
    float speed = 80;
    int sceneLength = 1644; //scene length - Mech width in pixels
    bool mechWalking = false;
    public GameObject background;
    public GameObject mech;
    public GameObject [] meters;

    [SerializeField]
    private GameObject Canvas;
    private UserInput input;

    [SerializeField]
    private GameObject scene1;
    [SerializeField]
    private GameObject scene2;
    [SerializeField]
    private GameObject scene3;

    [SerializeField]
    private Camera cam;

    private Vector3 camStartPoint;


    //Zonhgheng add: Not figure it out with the canvas size, something like 1644, 1844 and 940, use unit? for now
    // 1644 looks fine to me. There are some space outside of the camera, so I pick 1000 
    // we always let mech start at -9 and end at 11, which has 20 units.
    int sceneViewableLength = 1000;   //mech move 8/sec, needs 125s, sounds great to me.
    int mechStartPoint = -9;
    int mechEndPoint = 11;
    int unitDistance = 50;

    List<Queue<int>> checkpoint;
    int nextCheckPoint;
    int cameraCenterDistance = 300;
    int jumpDistance = 0;




    // Start is called before the first frame update
    void Start()
    {

        input = Canvas.GetComponent<UserInput>();
        camStartPoint = cam.transform.position;

        /*
        int targetScene1 = 4;
        int targetScene2 = 5;
        int targetScene3 = 2;
        */
        checkpoint = new List<Queue<int>>();
        Queue<int> scene1 = new Queue<int>();
        scene1.Enqueue(0);
        scene1.Enqueue(300);
        scene1.Enqueue(600);
        scene1.Enqueue(900);

        Queue<int> scene2 = new Queue<int>();
        scene2.Enqueue(0);
        scene2.Enqueue(200);
        scene2.Enqueue(400);
        scene2.Enqueue(600);
        scene2.Enqueue(950);

        Queue<int> scene3 = new Queue<int>();
        scene3.Enqueue(300);
        scene3.Enqueue(600);

        checkpoint.Add(scene1);
        checkpoint.Add(scene2);
        checkpoint.Add(scene3);

        nextCheckPoint = checkpoint[scene].Dequeue();

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
        if(distance >= sceneViewableLength){ //this code will assume scene is tied to locations and not unity scenes
            if(scene < 2){
                scene++;
                distance = 0;
                //change scene
                changeScene(scene);
                setMechWalking(true);

                //change background to scene
                positionObjectsV2();
            } else {
                //end event
                setMechWalking(false);
            }
            
        } /*else if (check if opening an event){
            //open event
        }
        */
    }

    private void changeScene(int scene)
    {
        if(scene == 0)
        {
            scene1.SetActive(true);
            scene2.SetActive(false);
            scene3.SetActive(false);
        }
        else if(scene == 1)
        {
            scene1.SetActive(false);
            scene2.SetActive(true);
            scene3.SetActive(false);
        }
        else if(scene == 2) {
            scene1.SetActive(false);
            scene2.SetActive(false);
            scene3.SetActive(true);
        }

        //update the nextCheckPoint
        nextCheckPoint = checkpoint[scene].Dequeue();
        input.updateScene(scene);
        cam.transform.position = camStartPoint;
        jumpDistance = 0;

    }

    public void changeDistance(int deltaDistance)
    {
        jumpDistance += deltaDistance;
        distance += deltaDistance;
    }

    void moveObjects (){

        distance+=speed*Time.deltaTime;

        //check if we meet the checkpoint
        if(Mathf.Abs(distance - nextCheckPoint) < 2)
        {
            //Trigger event
            setMechWalking(false);
            input.progress(scene);
            

            //reset checkPoint
            if(checkpoint[scene].Count != 0)
            {
                nextCheckPoint = checkpoint[scene].Dequeue();
            }
            else
            {
                nextCheckPoint = -100; //move to next
            }
        }

        positionObjectsV2();
    }

    public void setMechWalking(bool mechWalking)
    {
        this.mechWalking = mechWalking;
    }

    void positionObjects(){
        mech.transform.position = new Vector3 (distance, mech.transform.position.y , mech.transform.position.z);
        background.transform.position = new Vector3 (-distance*((1844-940)/sceneLength), background.transform.position.y , background.transform.position.z);
    }


    void positionObjectsV2()
    {
        mech.transform.position = new Vector3(mechStartPoint + (float)(distance / unitDistance), mech.transform.position.y, mech.transform.position.z);
        if (distance - jumpDistance >= cameraCenterDistance)
        {
            cam.transform.position = new Vector3(camStartPoint.x + (float)((distance - cameraCenterDistance - jumpDistance) / unitDistance), camStartPoint.y, camStartPoint.z);
            //always ask camera to move with player????
        }

    }
}
