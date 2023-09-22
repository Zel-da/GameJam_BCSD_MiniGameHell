using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float delay = 5f; // 딜레이 시간 (초)
    public string na;

    void Start()
    {
        // delay 초 후에 LoadNextScene 함수를 호출하여 다음 씬으로 이동합니다.
        Invoke("LoadNextScene", delay);
    }

    void LoadNextScene()
    {
        // 다음 씬으로 이동합니다. 씬의 이름이나 빌드 인덱스를 사용하여 이동할 수 있습니다.
        SceneManager.LoadScene(na);
    }
}