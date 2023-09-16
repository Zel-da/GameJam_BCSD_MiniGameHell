using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public List<Scores> theScores;
    
    void ScoreDatas()
    {
        theScores = new List <Scores>();
    }
}
