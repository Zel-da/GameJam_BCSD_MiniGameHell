using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bighit : MonoBehaviour
{
    private bool isMoving = true;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float moveSpeed = 5.0f;
    public                                float xMoveDistance = 5.0f;

    private void Start()
    {
        startPosition = transform.position;
        StartCoroutine(MoveObject());
    }

    private IEnumerator MoveObject()
    {
        while (true)
        {
            if (isMoving)
            {
                float randomY = Random.Range(-12.0f, 12.0f);
                targetPosition = new Vector3(transform.position.x, randomY, transform.position.z);
                float distance = Vector3.Distance(transform.position, targetPosition);
                float timeToReachTarget = distance / moveSpeed;

                yield return StartCoroutine(MoveToPosition(targetPosition, timeToReachTarget));

                targetPosition = new Vector3(transform.position.x + xMoveDistance, transform.position.y, transform.position.z);
                float xMoveTime = 1.0f; // x 위치로 빠르게 이동하는 데 걸리는 시간
                yield return StartCoroutine(MoveToPosition(targetPosition, xMoveTime));

                // 멈춘 후 초기 x 위치로 이동
                targetPosition = new Vector3(startPosition.x, transform.position.y, transform.position.z);
                float returnTime = 3.0f; // x 위치로 빠르게 이동하는 데 걸리는 시간
                yield return StartCoroutine(MoveToPosition(targetPosition, returnTime));

                // 다음 랜덤한 위치로 이동할 때까지 대기
                float waitTime = Random.Range(1.0f, 5.0f); // 다음 이동까지 대기 시간
                yield return new WaitForSeconds(waitTime);
            }
            else
            {
                yield return null;
            }
        }
    }

    private IEnumerator MoveToPosition(Vector3 target, float timeToReachTarget)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;

        while (elapsedTime < timeToReachTarget)
        {
            transform.position = Vector3.Lerp(startingPos, target, (elapsedTime / timeToReachTarget));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = target;
    }

    // 여기서 isMoving을 토글하는 메소드를 호출하면 오브젝트의 움직임을 일시 중지시킬 수 있습니다.
    public void ToggleMovement()
    {
        isMoving = !isMoving;
    }
}
