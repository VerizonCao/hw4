using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A Hacky file to store all the dialogues / text of the game. 

public class statChanges
{
    public int health;
    public int energy;
    public int distance;

    public statChanges (int health, int energy, int distance){
        this.health = health;
        this.energy = energy;
        this.distance = distance;
    }
}

public class Event
{
    public List<string> text;
    public List<string> options;
    public List<string> results;
    public List<statChanges> changes;
    // some stats result in the follow.

}


public class Narrative : MonoBehaviour
{
    
    private List<Event> events;

    public int loadSize()
    {
        return events.Count;
    }

    public Event getEventAtIndex(int index)
    {
        return events[index];
    }

    private void Awake()
    {
        events = new List<Event>();


        //adding all the events

        //1 |Area 1
        Event temp = new Event();
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
        temp.changes.Add(new statChanges(0,0,160));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);

        //2 random|Area 1
        Event temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("It seems that humans are not welcoming the mobile factory; some even harbor hostility towards this old factory. As the factory is about to move out of human settlements, all that is seen are neatly arranged wreaths and gravestones side by side.");

        temp.options = new List<string>();
        temp.options.Add("A Keep Moving");
        temp.options.Add("B Keep Moving");
        

        temp.results = new List<string>();
        temp.results.Add("Proceeding");
        temp.results.Add("Proceeding");

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);

        //3 random|Area 1
         Event temp = new Event();
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
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);

        //4 random|Area 1
         Event temp = new Event();
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
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);

        //5 random
         Event temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("");
        temp.text[0] += "";
        temp.text[0] += "";

        temp.text.Add("");
        temp.text[1] += "";

        temp.options = new List<string>();
        temp.options.Add("");
        temp.options.Add("");
        

        temp.results = new List<string>();
        temp.results.Add("");
        temp.results[0] += "";
        temp.results.Add("");
        temp.results[1] += "";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);

        //6 random
         Event temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("");
        temp.text[0] += "";
        temp.text[0] += "";

        temp.text.Add("");
        temp.text[1] += "";

        temp.options = new List<string>();
        temp.options.Add("");
        temp.options.Add("");
        

        temp.results = new List<string>();
        temp.results.Add("");
        temp.results[0] += "";
        temp.results.Add("");
        temp.results[1] += "";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);

        //7 random
         Event temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("");
        temp.text[0] += "";
        temp.text[0] += "";

        temp.text.Add("");
        temp.text[1] += "";

        temp.options = new List<string>();
        temp.options.Add("");
        temp.options.Add("");
        

        temp.results = new List<string>();
        temp.results.Add("");
        temp.results[0] += "";
        temp.results.Add("");
        temp.results[1] += "";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);

        //8 random
         Event temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("");
        temp.text[0] += "";
        temp.text[0] += "";

        temp.text.Add("");
        temp.text[1] += "";

        temp.options = new List<string>();
        temp.options.Add("");
        temp.options.Add("");
        

        temp.results = new List<string>();
        temp.results.Add("");
        temp.results[0] += "";
        temp.results.Add("");
        temp.results[1] += "";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);

        //9 random
         Event temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("");
        temp.text[0] += "";
        temp.text[0] += "";

        temp.text.Add("");
        temp.text[1] += "";

        temp.options = new List<string>();
        temp.options.Add("");
        temp.options.Add("");
        

        temp.results = new List<string>();
        temp.results.Add("");
        temp.results[0] += "";
        temp.results.Add("");
        temp.results[1] += "";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);
        
        //10 random
        Event temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("");
        temp.text[0] += "";
        temp.text[0] += "";

        temp.text.Add("");
        temp.text[1] += "";

        temp.options = new List<string>();
        temp.options.Add("");
        temp.options.Add("");
        

        temp.results = new List<string>();
        temp.results.Add("");
        temp.results[0] += "";
        temp.results.Add("");
        temp.results[1] += "";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);

        //11 random
         Event temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("");
        temp.text[0] += "";
        temp.text[0] += "";

        temp.text.Add("");
        temp.text[1] += "";

        temp.options = new List<string>();
        temp.options.Add("");
        temp.options.Add("");
        

        temp.results = new List<string>();
        temp.results.Add("");
        temp.results[0] += "";
        temp.results.Add("");
        temp.results[1] += "";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);

        //12 random
         Event temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("");
        temp.text[0] += "";
        temp.text[0] += "";

        temp.text.Add("");
        temp.text[1] += "";

        temp.options = new List<string>();
        temp.options.Add("");
        temp.options.Add("");
        

        temp.results = new List<string>();
        temp.results.Add("");
        temp.results[0] += "";
        temp.results.Add("");
        temp.results[1] += "";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);

        //16 random
         Event temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("");
        temp.text[0] += "";
        temp.text[0] += "";

        temp.text.Add("");
        temp.text[1] += "";

        temp.options = new List<string>();
        temp.options.Add("");
        temp.options.Add("");
        

        temp.results = new List<string>();
        temp.results.Add("");
        temp.results[0] += "";
        temp.results.Add("");
        temp.results[1] += "";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);

        //17 
         Event temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("");
        temp.text[0] += "";
        temp.text[0] += "";

        temp.text.Add("");
        temp.text[1] += "";

        temp.options = new List<string>();
        temp.options.Add("");
        temp.options.Add("");
        

        temp.results = new List<string>();
        temp.results.Add("");
        temp.results[0] += "";
        temp.results.Add("");
        temp.results[1] += "";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);

        //final 
         Event temp = new Event();
        temp.text = new List<string>();
        temp.text.Add("");
        temp.text[0] += "";
        temp.text[0] += "";

        temp.text.Add("");
        temp.text[1] += "";

        temp.options = new List<string>();
        temp.options.Add("");
        temp.options.Add("");
        

        temp.results = new List<string>();
        temp.results.Add("");
        temp.results[0] += "";
        temp.results.Add("");
        temp.results[1] += "";

        temp.changes = new List<statChanges>();
        temp.changes.Add(new statChanges(0,0,0));
        temp.changes.Add(new statChanges(0,0,0));

        events.Add(temp);


    }

    void Start()
    {
        

    }

    


}
