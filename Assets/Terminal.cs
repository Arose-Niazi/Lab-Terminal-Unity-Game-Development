using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{

    GameObject creat_game_object()
    {
        return null;
    }
    //whenever it is called it creates a game object at position (0,0,0)
    //and return it.

    Vector3 get_position(GameObject go)
    {
        return Vector3.back;
    }
    //return the position of the object.
    void set_position(GameObject go, Vector3 pos)
    {
        
    }
    //set the position of game object.
    void move_towards(int s , GameObject g1 , GameObject g2);
    {
        
    }
    //move g1 towards g2 with speed s.

    int distance_betweeen(GameObject g1, GameObject g2)
    {
        return 0;
    }
    //returns distance between two gameobjects.
    Vector3 random()
    {
        return Vector3.back;
    }
    //it returns random vector3 value.
    void make_it_child(GameObject g1, GameObject g2);
    {
        
    }
    //makes g2 child of g1.
    void destroy_All()
    {
        
    }
    //destroy all gameobjects;
    // Start is called before the first frame update

    private ArrayList myObjects = new ArrayList();
    private GameObject first;
    private GameObject center;
    private GameObject second;

    void PartA()
    {
        center = creat_game_object();
        for (int i = 0; i < 10; i++)
        {
            myObjects.Add(creat_game_object());
            set_position(myObjects[i] as GameObject, random());
        }
        
    }
    
    void PartB()
    {
        first = myObjects[0] as GameObject;
        
        foreach (GameObject obj in myObjects)
        {
            if (distance_betweeen(center, obj) > distance_betweeen(center, first))
                first = obj;
        }
        
        myObjects.Remove(first);
    }

    void PartC()
    {
        second = myObjects[0] as GameObject;
        foreach (GameObject obj in myObjects)
        {
            if (distance_betweeen(center, obj) > distance_betweeen(center, second))
                second = obj;
        }
        move_towards(10, first, second);
    }

    void PartD()
    {
        if(distance_betweeen(first , second) < 1)
        {
            make_it_child(first,second);
            myObjects.Remove(second);
        }
    }

    void Part_E()
    {
        while (myObjects.Count > 0)
        {
            PartC();
            PartD();
        }
    }

    void PartF()
    {
        move_towards(10, first, center);
    }

    void PartG()
    {
        if(distance_betweeen(first , center) < 1)
            destroy_All();
        PartA();
    }

    void arrange_by_tag(GameObject[] go)
    {
        Array.Sort(go, (g1,g2)=>String.Compare(g1.tag, g2.tag, StringComparison.Ordinal));
    }

    void parents_list(GameObject go)
    {
        var checking = go;
        if(checking.transform.parent == null)
            Debug.Log("Object has no Parent");
        while (go.transform.parent != null)
        {
            Debug.Log(go.transform.parent.name);
            
        }
    }
}
