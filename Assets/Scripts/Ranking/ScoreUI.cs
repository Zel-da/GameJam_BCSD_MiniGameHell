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
        scoresManager.AddScore(new Scores(names: "user1", scores: 0));
        scoresManager.AddScore(new Scores(names: "user2", scores: 0));

        var theScores = scoresManager.GetHighScores().ToArray();
        for (int i = 0; i < theScores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.ranks.text = (i + 1).ToString();
            row.names.text = theScores[i].names;
            row.scores.text = theScores[i].scores.ToString();
        }
    }

}
