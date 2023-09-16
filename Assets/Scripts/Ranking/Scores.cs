using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scores
{
    public string names;
    public float scores;

    public Scores(string names, float scores)
    {
        this.names = names;
        this.scores = scores;
    }
}
