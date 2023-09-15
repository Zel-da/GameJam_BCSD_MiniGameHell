using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTree : MonoBehaviour
{
    public GameObject tree; // GameObject 자료형인 tree 변수 생성
                            // prefab을 tree 변수 안에 넣기 위해
    float timer = 1.5f; // 타이머
    public float timediff; // 시간 간격

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // timer가 1 == 1초가 흐른 것
        if (timer > timediff) // timediff초가 흐른 시점에
        {
            GameObject newtree = Instantiate(tree); // prefab 찍어내는 newtree 변수 생성
            newtree.transform.position = new Vector3(Random.Range(-3.5f, 3.5f), -6, 0); // x좌표 랜덤하게 설정
            timer = 0;
            Destroy(newtree, 6.0f); // 6초 뒤에 pipe 삭제
        }
    }
}