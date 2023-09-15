using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string nextSceneName; // Inspector에서 다음 씬 이름을 할당

    public void OnClick()
    {
        SceneManager.LoadScene(nextSceneName); // 다음 씬으로 전환
    }
}