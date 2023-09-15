using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform pointA;
    public Transform pointB;
    public int vertexCount = 10; // 라인 렌더러의 버텍스 수
    public float curveWidth = 1.0f; // 두 곡선 간격

    private Vector3[] linePositions;

    void Start()
    {
        lineRenderer.positionCount = vertexCount * 2;
        linePositions = new Vector3[vertexCount * 2];

        StartCoroutine(GenerateCurves());
    }

    IEnumerator GenerateCurves()
    {
        while (true)
        {
            for (int i = 0; i < vertexCount; i++)
            {
                float t = i / (float)(vertexCount - 1);
                linePositions[i] = Vector3.Lerp(pointA.position, pointB.position, t);
                linePositions[i + vertexCount] = Vector3.Lerp(pointA.position, pointB.position, t) + Vector3.up * curveWidth;
            }

            lineRenderer.SetPositions(linePositions);

            // 사이의 간격을 좁히거나 넓힘
            curveWidth += Mathf.Sin(Time.time) * 0.1f;

            yield return new WaitForSeconds(0.1f); // 새로운 곡선 생성까지의 대기 시간
        }
    }
}