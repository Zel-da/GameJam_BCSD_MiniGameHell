using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public List<Scores> theScores;
    
    public void ScoreDatas()
    {
        theScores = new List <Scores>();
    }
}
