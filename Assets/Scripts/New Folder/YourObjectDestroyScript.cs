using UnityEngine;

public class YourObjectDestroyScript : MonoBehaviour
{
    // 특정 오브젝트가 파괴될 때 호출됩니다.
    private void OnDestroy()
    {
        // 원하는 동작을 수행합니다.
        Debug.Log("특정 오브젝트가 파괴되었습니다.");

        // 이벤트를 호출합니다.
        if (OnObjectDestroy != null)
        {
            OnObjectDestroy();
        }
    }

    // 이벤트 델리게이트 선언
    public delegate void ObjectDestroyAction();
    public event ObjectDestroyAction OnObjectDestroy;
}