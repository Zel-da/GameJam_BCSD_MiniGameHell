using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // 점수를 표시할 Text 엘리먼트
    public float scoreIncreaseInterval = 0.1f; // 점수를 증가시키는 주기 (예: 1초마다)
    public int scoreIncreaseAmount = 10; // 점수가 증가하는 양

    public int score = 0;
    private float timeSinceLastIncrease = 0.0f;
    private bool isScoreStopped = false;



    void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        if (!isScoreStopped) // 점수 증가 중지되지 않았을 때만 증가
        {
            // 경과한 시간을 누적
            timeSinceLastIncrease += Time.deltaTime;

            // scoreIncreaseInterval 간격마다 점수를 증가
            if (timeSinceLastIncrease >= scoreIncreaseInterval)
            {
                IncreaseScore(scoreIncreaseAmount);
                timeSinceLastIncrease = 0.0f; // 시간 초기화
            }
        }
    }

        // 점수를 증가시키는 메소드
        public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    // Text 엘리먼트에 현재 점수를 업데이트하는 메소드
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void StopScore()
    {
        isScoreStopped = true;
    }
}
