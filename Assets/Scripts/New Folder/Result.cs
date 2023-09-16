using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public GameObject[] objectsToActivate; // 활성화할 오브젝트들

    private bool isPaused = false; // 게임 퍼즈 상태 여부

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) // 예제로 'P' 키를 눌렀을 때 퍼즈 토글
        {
            TogglePause();
        }
    }

    // 퍼즈 상태를 토글합니다.
    void TogglePause()
    {
        isPaused = !isPaused;

        // 퍼즈 상태일 때 활성화할 오브젝트를 활성화하고,
        // 언퍼즈 상태일 때 비활성화합니다.
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(isPaused);
        }

        // 시간 스케일을 조절하여 게임 일시정지/언파즈 효과를 줍니다.
        if (isPaused)
        {
            Time.timeScale = 0f; // 게임 일시정지
        }
        else
        {
            Time.timeScale = 1f; // 게임 언파즈
        }
    }
}
