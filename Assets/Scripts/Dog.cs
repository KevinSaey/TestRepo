using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog 
{
    private string _name;
    private string _collar;

    public Dog(string name, string collar)
    {
        _name = name;
        _collar = collar;

        Debug.Log("dog created");
    }

    public void Bark(int amounts)
    {
        for (int i = 0; i < amounts; i++)
        {
            Debug.Log("Woef " + _name);
        }
        
    }
    

}
