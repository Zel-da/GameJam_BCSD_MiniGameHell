using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public AudioSource audioSource; // 오디오 소스 컴포넌트를 연결할 변수
    public GameObject objectToDeactivate; // 비활성화할 오브젝트를 연결할 변수

    public void OnClick()
    {
        // 오디오 소리 재생
        audioSource.Play();

        // 오브젝트 비활성화
        objectToDeactivate.SetActive(false);

        Time.timeScale = 1f;
    }
}
