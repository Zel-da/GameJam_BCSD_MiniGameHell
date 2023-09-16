using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0; // 점수

    // Start is called before the first frame update
    void Start()
    {
        score = 0; // 시작할 때마자 점수 초기화
    }
}