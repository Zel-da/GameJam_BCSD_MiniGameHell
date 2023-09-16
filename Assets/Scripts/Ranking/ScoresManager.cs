using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoresManager : MonoBehaviour
{
    private ScoreData sd;

    void Awake()
    {
        string jsonString = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(jsonString);
    }

    public IEnumerable<Scores> GetHighScores()
    {
        return sd.theScores.OrderByDescending(x => x.scores);
    }

    public void AddScore(Scores scores)
    {
        sd.theScores.Add(scores);
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        string jsonString = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", jsonString);
    }
}
