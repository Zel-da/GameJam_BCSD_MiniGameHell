using UnityEngine;

public class PauseOnObjectDestroy : MonoBehaviour
{
    public GameObject[] objectsToActivate; // 활성화할 오브젝트들
    public GameObject objectToDestroy; // 특정 오브젝트

    private bool isPaused = false; // 게임 퍼즈 상태 여부

    private void Start()
    {
        objectToDestroy.GetComponent<YourObjectDestroyScript>().OnObjectDestroy += PauseAndActivate;
    }

    // 게임을 퍼즈하고 다른 오브젝트를 활성화합니다.
    private void PauseAndActivate()
    {
        isPaused = true;

        // 퍼즈 상태일 때 활성화할 오브젝트를 활성화합니다.
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }

        // 시간 스케일을 조절하여 게임을 일시정지합니다.
        //Time.timeScale = 0f; // 게임 일시정지
    }
}
