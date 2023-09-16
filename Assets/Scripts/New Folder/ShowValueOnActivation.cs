using UnityEngine;
using UnityEngine.UI;

public class ShowValueOnActivation : MonoBehaviour
{
    public GameObject targetObject; // 값을 가져올 대상 오브젝트
    public Text displayText; // 값을 표시할 UI Text 컴포넌트

    private void OnEnable()
    {
        if (targetObject != null && displayText != null)
        {
            // 다른 오브젝트의 값을 가져와서 텍스트로 표시
            int valueToDisplay = targetObject.GetComponent<ScoreManager>().score; // YourScript와 yourValue를 실제 스크립트와 변수명에 맞게 수정
            displayText.text = "Score: " + valueToDisplay.ToString();
        }
        else
        {
            Debug.LogWarning("Target object or display text is not assigned.");
        }
    }
}
