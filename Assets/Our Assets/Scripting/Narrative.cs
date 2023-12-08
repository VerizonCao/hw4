using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A Hacky file to store all the dialogues / text of the game. 

public class statChanges
{
    public int health;
    public int energy;
    public int distance;

    public statChanges(int health, int energy, int distance)
    {
        this.health = health;
        this.energy = energy;
        this.distance = distance;
    }
}

public enum EventType
{
    must,
    random
}

public class Event
{
    public List<string> text;
    public List<string> options;
    public List<string> results;
    public List<statChanges> changes;
    // some stats result in the follow.
    public EventType eventType;

    public Event()
    {
        eventType = EventType.random;
    }

    public Event(EventType type)
    {
        eventType = type;
    }

}


public class Narrative : MonoBehaviour
{

    private List<List<Event>> events;
    private Event scene1Start;
    private Event scene2Start;
    private Event scene2End;
    private Event scene3Start;
    private Event scene3Ending;

    public int loadSize()
    {
        return events.Count;
    }

    public Event getEventAtIndex(int scene, int index)
    {
        return events[scene][index];
    }

    public List<Event> getEventsAtScene(int scene)
    {
        return events[scene];
    }

    public Event getScene1Start()
    {
        return scene1Start;
    }

    public Event getScene2Start()
    {
        return scene2Start;
    }

    public Event getScene2End()
    {
        return scene2End;
    }

    public Event getScene3Start()
    {
        return scene3Start;
    }

    public Event getScene3Ending()
    {
        return scene3Ending;
    }



    private void Awake()
    {
        events = new List<List<Event>>();
        events.Add(new List<Event>());  //scene 1
        events.Add(new List<Event>());  //scene 2
        events.Add(new List<Event>());  //scene 3


        //adding all the events

        //1 |Area 1
        Event temp = new Event(EventType.must);
        temp.text = new List<string>();
        temp.text.Add("The old machine wakes up in a small inhabited area; it is a large mobile factory, and the factory starts heading towards the Northern Plains Biome.");

        temp.options = new List<string>();
        temp.options.Add("A Proceed");
        temp.options.Add("B Reorient");


        temp.results = new List<string>();
        temp.results.Add("Travel Distance decreased");
        temp.results[0] += "WARNING damage to human settlement detected";
        temp.results.Add("Alternative route set");
        temp.results[1] += "Proceeding";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0, 0, 160));
        temp.changes.Add(new statChanges(0, 0, 0));

        //events[0].Add(temp);
        scene1Start = temp;

        //2 random|Area 1
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("It seems that humans are not welcoming the mobile factory; some even harbor hostility towards this old factory. As the factory is about to move out of human settlements, all that is seen are neatly arranged wreaths and gravestones side by side.");

        temp.options = new List<string>();
        temp.options.Add("A Keep Moving");
        temp.options.Add("B Keep Moving");


        temp.results = new List<string>();
        temp.results.Add("Proceeding");
        temp.results.Add("Proceeding");

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0, 0, 0));
        temp.changes.Add(new statChanges(0, 0, 0));

        events[0].Add(temp);

        //3 random|Area 1
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("Wandering through the ruins of a former human city, an alert is triggered by the old factory's sensors. An electrical storm is converging on its location. While this may be useful for gathering some excess charge for the journey ahead, the risk of structural damage is also incredibly high. Shelter might be advisable.");

        temp.options = new List<string>();
        temp.options.Add("A Continue");
        temp.options.Add("B Shelter");


        temp.results = new List<string>();
        temp.results.Add("Proceeding");
        temp.results[0] += "Solarite charge partially replenished";
        temp.results[0] += "WARNING extensive hull damage sustained";
        temp.results.Add("Seeking shelter");
        temp.results[1] += "Shelter found";
        temp.results[1] += "...";
        temp.results[1] += "...";
        temp.results[1] += "Storm passed";
        temp.results[1] += "Energy lost in waiting period";
        temp.results[1] += "Resuming journey";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0, 0, 0));
        temp.changes.Add(new statChanges(0, 0, 0));

        events[0].Add(temp);

        //4 random|Area 1
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("An old factory encountered a group of destitute refugees while carrying out its final mission. On the way, they approached, requesting a ride for a short distance as they were too exhausted and in need of a brief rest.");

        temp.options = new List<string>();
        temp.options.Add("A Agree to give them a ride");
        temp.options.Add("B  Ignore them and keep moving");


        temp.results = new List<string>();
        temp.results.Add("Energy drain from excess weight");
        temp.results[0] += "Superficial hull damage sustained";
        temp.results[0] += "...";
        temp.results[0] += "Human occupants have departed";
        temp.results[0] += "Human occupants appear unharmed";
        temp.results.Add("Proceeding");

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(-30, -100, 0));
        temp.changes.Add(new statChanges(0, 0, 0));

        events[0].Add(temp);

        //5 random|Area 1
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("During the journey, passing by a dilapidated craftsman's hut, the craftsman is preparing to leave this place to seek a living elsewhere. He happens to need some energy to charge his vehicle. He proposes to make a deal with you – if you provide him with some energy, he will do his best to replace your old parts.");

        temp.options = new List<string>();
        temp.options.Add("A Agree to the deal");
        temp.options.Add("B Ignore the deal");

        temp.results = new List<string>();
        temp.results.Add("Structural integrity partially restored");
        temp.results[0] += "WARNING charge decreasing at an accelerated rate";
        temp.results[0] += "charge discrepency resolved";
        temp.results.Add("Proceeding");

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(50, -75, 0));
        temp.changes.Add(new statChanges(0, 0, 0));

        events[0].Add(temp);

        //6 random|Area 1
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("The factory meets a Craftsman, he tries to make a deal with you. He needs to find new parts for his vehicle, and you happen to have some. And he will provide you with some energy to help you go further.");

        temp.options = new List<string>();
        temp.options.Add("A Give him the gear he needs");
        temp.options.Add("B Ignore the deal, Keep moving");


        temp.results = new List<string>();
        temp.results.Add("Siphoning charge");
        temp.results[0] += "WARNING components have been removed";
        temp.results[0] += "Priority: Non-Essential";
        temp.results.Add("Proceeding");

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(-75, 50, 0));
        temp.changes.Add(new statChanges(0, 0, 0));

        events[0].Add(temp);

        //7 random|Area 1
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("The mobile factory encountered a settlement of refugees who expressed their desire to accompany it for a portion of the journey to ensure their safety. In return, they offered to provide some energy resources and assist with simple repairs to the factory.");

        temp.options = new List<string>();
        temp.options.Add("A Allow them to follow you ");
        temp.options.Add("B Leave them and keep moving.");


        temp.results = new List<string>();
        temp.results.Add("Human Group A present");
        temp.results[0] += "Standard wear and tear experienced";
        temp.results[0] += "Standard maintanence resuming";
        temp.results[0] += "Proceeding";
        temp.results[0] += "...";
        temp.results[0] += "Human Group A leaving sensor radius";
        temp.results.Add("Proceeding");

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0, 0, 0));
        temp.changes.Add(new statChanges(0, 0, 0));

        events[0].Add(temp);

        //8 Area 2
        temp = new Event(EventType.must);
        temp.text = new List<string>();
        temp.text.Add("Due to the intense radiation from the power reactor, the mechanical system of the factory experienced a brief paralysis, and a system error triggered a sleep mode. It appears that the mechanical factory conducted a database check to rectify the system error, but most images were severely damaged. There are several intact images, one of which depicts a seed being planted underground. The sleep mode came to an end.");

        temp.options = new List<string>();
        temp.options.Add("A Keep Moving");
        temp.options.Add("B Keep Moving");


        temp.results = new List<string>();
        temp.results.Add("... I am so tired");
        temp.results.Add("... I will keep them safe");

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0, 0, 0));
        temp.changes.Add(new statChanges(0, 0, 0));

        //events[1].Add(temp);
        scene2Start = temp;

        //9 random|Area 2
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("In the quiet wilderness, a place that should have been devoid of any sound suddenly acquired a rhythmic noise. An antiquated machine continued its operation, but it had no choice but to come to a halt. Up ahead, the remnants left by war obstructed its path. Perhaps, in the past, clearing war debris was a part of its duties. However, now it felt powerless in the face of the wreckage left by the conflict.");

        temp.options = new List<string>();
        temp.options.Add("A Use body To crush the remnant");
        temp.options.Add("B Find another way to the destination");


        temp.results = new List<string>();
        temp.results.Add("Proceeding");
        temp.results[0] += "WARNING Structural damage sustained";
        temp.results[0] += "WARNING Structural damage sustained";
        temp.results[0] += "Obstacle navigation successful";
        temp.results.Add("Alternative route set");
        temp.results[1] += "Proceeding";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(-200, 0, 320));
        temp.changes.Add(new statChanges(0, 0, 0));

        events[1].Add(temp);

        //10 random|Area 2
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("The factory arrived at a heavily polluted area, and its cleaning program instructed it to clean up the surrounding environment. However, cleaning this area might take some time, and it would make mechanic error. Nevertheless, cleaning up polluted areas is part of its duties as a custodian.");

        temp.options = new List<string>();
        temp.options.Add("A Clean the place");
        temp.options.Add("B Keep Moving");


        temp.results = new List<string>();
        temp.results.Add("Commencing cleaning protocals");
        temp.results[0] += "...";
        temp.results[0] += "...";
        temp.results[0] += "Cleaning complete";
        temp.results[0] += "Damage sustained and charge lost within standard use parameters";
        temp.results.Add("Proceeding");

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(-25, -100, 0));
        temp.changes.Add(new statChanges(0, 0, 0));

        events[1].Add(temp);

        //11 random|Area 2
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("The old factory arrived at a severely polluted area, where buildings seemed on the verge of collapsing any second, and an attack might be imminent. However, it had no choice but to stop here, as the terrain ahead was uneven with craters at the bottom of the river, making it highly likely that once it moved forward, it might not return.");

        temp.options = new List<string>();
        temp.options.Add("A Quickly cross the river");
        temp.options.Add("B Slowly cross the river using sensors");


        temp.results = new List<string>();
        temp.results.Add("Proceeding");
        temp.results[0] += "WARNING Structural damage sustained";
        temp.results[0] += "WARNING Structural damage sustained";
        temp.results[0] += "Obstacle navigation successful";
        temp.results.Add("Proceeding");
        temp.results[1] += "Obstacle detected... redirecting";
        temp.results[1] += "Obstacle detected... redirecting";
        temp.results[1] += "Obstacle detected... redirecting";
        temp.results[1] += "Obstacle navigation successful";
        temp.results[1] += "Energy efficiency decreased during traversal";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(-100, 0, 0));
        temp.changes.Add(new statChanges(0, -100, 0));

        events[1].Add(temp);

        //12 random|Area 2
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("The old factory's system detected sounds ahead—bandits were attacking refugees. The refugees appeared defenseless, and the bandits seemed unaware of the mobile factory's presence. As a machine created by humans, the Three Laws of Robotics dictated that the machine should protect humans. However, the Odyssey Protocol instructed minimizing mechanical wear and energy consumption. Yet, the only thing it could do was stand in front of the refugees.");

        temp.options = new List<string>();
        temp.options.Add("A Help refugees");
        temp.options.Add("B Keep processing the Odyssey Protocol");


        temp.results = new List<string>();
        temp.results.Add("Intervening in human combat situation");
        temp.results[0] += "WARNING Hull damage sustained";
        temp.results[0] += "WARNING structural integrity decreased";
        temp.results[0] += "Scanning for humans";
        temp.results[0] += "Human group A has left immediate vicinity";
        temp.results[0] += "Human group B ceasing hostilities";
        temp.results.Add("Proceeding");
        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(-200, -25, -32));
        temp.changes.Add(new statChanges(0, 0, 0));

        events[1].Add(temp);

        //13 random|Area 2
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("The mobile factory, dragging its cumbersome frame, moved towards the depths of the ruins. System detection revealed the presence of several Cleaners. They appeared to have moved here together, but unfortunately, their bodies had long been scrapped, and their systems were shut down just before reaching their final destination. However, there was still residual energy in their power sources.");

        temp.options = new List<string>();
        temp.options.Add("A Take their energy");
        temp.options.Add("B May they rest in the peace");


        temp.results = new List<string>();
        temp.results.Add("Siphoning charge");
        temp.results.Add("Proceeding");

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0, 100, 0));
        temp.changes.Add(new statChanges(0, 0, 0));

        events[1].Add(temp);

        //14 random|Area 2
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("Navigating through the rubble, the factory detected an undetonated energy bomb. This might not be an ideal time to disarm the bomb as it seemed poised to explode at any moment. Moreover, disarming the bomb may not provide any direct benefit to the factory. However, system analysis revealed that the energy source inside the bomb was brand new.");

        temp.options = new List<string>();
        temp.options.Add("A  Defuse the Bomb");
        temp.options.Add("B Quickly Move out from the area");


        temp.results = new List<string>();
        temp.results.Add("Defusal process started");
        temp.results[0] += "...";
        temp.results[0] += "WARNING Massive hull damage sustained";
        temp.results[0] += "Defusal Process failed";
        temp.results.Add("Proceeding");

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(-200, 0, 0));
        temp.changes.Add(new statChanges(0, 0, 0));

        events[1].Add(temp);

        //15 random|Area 2
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("Navigating through the rubble, the factory detected an undetonated energy bomb. This might not be an ideal time to disarm the bomb as it seemed poised to explode at any moment. Moreover, disarming the bomb may not provide any direct benefit to the factory. However, system analysis revealed that the energy source inside the bomb was brand new.");

        temp.options = new List<string>();
        temp.options.Add("A  Defuse the Bomb");
        temp.options.Add("B Quickly Move out from the area");


        temp.results = new List<string>();
        temp.results.Add("Defusal process started");
        temp.results[0] += "...";
        temp.results[0] += "...";
        temp.results[0] += "Defusal process successful";
        temp.results[0] += "Excess charge siphoned";
        temp.results.Add("Proceeding");

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0, 25, 0));
        temp.changes.Add(new statChanges(0, 0, 0));

        events[1].Add(temp);

        //16 random|Area 2
        temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("Navigating through the extensive debris, a warning sign emerged up ahead, indicating a  solar mine is in a severely radiated area. It could be a severely energy-contaminated area, given the apparent devastation of war remnants ahead. System analysis suggested that traversing through this area would significantly reduce travel time, potentially minimizing the damage that the mobile factory might incur.");

        temp.options = new List<string>();
        temp.options.Add("A  walk through the dangerous area");
        temp.options.Add("B  Find another way");


        temp.results = new List<string>();
        temp.results.Add("Proceeding");
        temp.results[0] += "WARNING Structural damage sustained";
        temp.results[0] += "WARNING Structural damage sustained";
        temp.results[0] += "Obstacle navigation successful";
        temp.results.Add("Alternative route set");
        temp.results[1] += "Proceeding";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(-100, 0, 250));
        temp.changes.Add(new statChanges(0, 0, 0));

        events[1].Add(temp);

        //17 Area 2
        temp = new Event(EventType.must);
        temp.text = new List<string>();
        temp.text.Add("Due to the intense radiation from the power reactor, the mechanical system of the factory experienced a brief paralysis, and a system error triggered a sleep mode. It appears that the mechanical factory conducted a database check to rectify the system error, but most images were severely damaged. There are several intact images, one of which depicts a seed being planted underground. The sleep mode came to an end.");

        temp.options = new List<string>();
        temp.options.Add("A Keep Moving");
        temp.options.Add("B Keep Moving");


        temp.results = new List<string>();
        temp.results.Add("... I am so tired");
        temp.results.Add("... I will keep them safe");

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0, 0, 0));
        temp.changes.Add(new statChanges(0, 0, 0));

        //events[1].Add(temp);
        scene2End = temp;

        //18 Area 3
        temp = new Event(EventType.must);
        temp.text = new List<string>();
        temp.text.Add("As everything was approaching its conclusion, the old factory encountered another severely damaged factory that was also on the brink of its final rest. The two machines locked eyes, as if communicating something profound without words");

        temp.options = new List<string>();
        temp.options.Add("A Take it with you");
        temp.options.Add("B Ignore Him.");


        temp.results = new List<string>();
        temp.results.Add("Attaching to fellow unit");
        temp.results[0] += "Energy efficiency decreased";
        temp.results[0] += "Proceeding";
        temp.results.Add("Proceeding");
        temp.results[1] += "...";
        temp.results[1] += "OVERRIDE";
        temp.results[1] += "Attaching to fellow unit";
        temp.results[1] += "Energy efficiency decreased";
        temp.results[1] += "Proceeding";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0, -50, 0));
        temp.changes.Add(new statChanges(0, -50, 0));

        //events[2].Add(temp);
        scene3Start = temp;

        //final 
        temp = new Event(EventType.must);
        temp.text = new List<string>();
        temp.text.Add("The factory traveled through a grove of trees, and eventually, the trees thinned out into a dusty expanse. As the mobile factory faced dwindling energy, body damage, and system crashes, it encountered an unexpected sight. Machines aren't supposed to experience illusions, but before its eyes appeared a lush grassland, where many similar factories were in a state of dormancy. Yes, everything was coming to an end. Finally, the factory reached a tree and entered into a deep slumber.");

        temp.options = new List<string>();
        temp.options.Add("A Deep Sleep");
        temp.options.Add("B Deep Sleep");

        temp.results = new List<string>();
        temp.results.Add("... Finally I am done");
        temp.results.Add("... Finally they are safe");

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0, 0, 0));
        temp.changes.Add(new statChanges(0, 0, 0));

        //events[2].Add(temp);
        scene3Ending = temp;
    }

    void Start()
    {


    }




}