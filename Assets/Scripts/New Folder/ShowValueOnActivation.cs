using UnityEngine;
using UnityEngine.UI;

public class ShowValueOnActivation : MonoBehaviour
{
    public GameObject targetObject; // 값을 가져올 대상 오브젝트
    public Text displayText; // 값을 표시할 UI Text 컴포넌트
    public ScoresManager scoresManager;
    public int i;
    int a;

    private void OnEnable()
    {
        if (targetObject != null && displayText != null)
        {
            // 다른 오브젝트의 값을 가져와서 텍스트로 표시
            int valueToDisplay = targetObject.GetComponent<ScoreManager>().score; // YourScript와 yourValue를 실제 스크립트와 변수명에 맞게 수정
            displayText.text = "Score: " + valueToDisplay.ToString();


            a = PlayerPrefs.GetInt("Score"); // 이미 저장된 점수 가져오기

            a += valueToDisplay;
            PlayerPrefs.SetInt("Score", a);

            if ( i == 1 )
            {
                Scores newScore = new Scores(a); // PlayerName과 100은 예시입니다.
                scoresManager.AddScore(newScore);

                PlayerPrefs.SetInt("Score", 0);
                i = 0;
            }
        }
        else
        {
            Debug.LogWarning("Target object or display text is not assigned.");
        }
    }
}
