using UnityEngine;
using UnityEngine.SceneManagement;

public class ChildObjectCounter : MonoBehaviour
{
    public int targetCount = 6; // 목표 카운트

    public static int currentCount; // 정적 변수로 변경

    void Start()
    {
        if (currentCount == 0)
            currentCount = targetCount; // 초기 카운트를 목표 카운트로 설정 (처음에 한 번만 수행)

        UpdateCount();
    }

    void UpdateCount()
    {
        if (currentCount <= 0)
        {
            // 카운트가 0 이하로 떨어지면 게임을 정지하거나 원하는 동작을 수행합니다.
            Debug.Log("게임 정지 - 목표 카운트에 도달했습니다.");
            Time.timeScale = 0f; // 게임을 정지합니다 (시간 스케일을 0으로 설정).
            // 게임 정지 후 원하는 작업을 수행하거나 씬을 재시작할 수 있습니다.
        }
    }

    // 오브젝트가 사라질 때 호출됩니다.
    public void ObjectDestroyed()
    {
        currentCount--; // 카운트 감소
        UpdateCount();
    }
}
