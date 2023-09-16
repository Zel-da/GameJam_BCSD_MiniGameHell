using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreUI : MonoBehaviour
{
    public RowUI rowUI;
    public ScoresManager scoresManager;

    void Start()
    {
        scoresManager.AddScore(new Scores(scores: 1));
        scoresManager.AddScore(new Scores(scores: 2));
        scoresManager.AddScore(new Scores(scores: 3));
        scoresManager.AddScore(new Scores(scores: 4));
        scoresManager.AddScore(new Scores(scores: 5));

        var theScores = scoresManager.GetHighScores().ToArray();
        for (int i = 0; i < 5; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.ranks.text = (i + 1).ToString();
            row.scores.text = theScores[i].scores.ToString();
        }
    }

}
