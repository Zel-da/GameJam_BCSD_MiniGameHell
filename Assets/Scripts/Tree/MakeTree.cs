using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTree : MonoBehaviour
{
    public GameObject tree; // GameObject �ڷ����� tree ���� ����
                            // prefab�� tree ���� �ȿ� �ֱ� ����
    float timer = 1.5f; // Ÿ�̸�
    public float timediff; // �ð� ����

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // timer�� 1 == 1�ʰ� �帥 ��
        if (timer > timediff) // timediff�ʰ� �帥 ������
        {
            GameObject newtree = Instantiate(tree); // prefab ���� newtree ���� ����
            newtree.transform.position = new Vector3(Random.Range(-3.5f, 3.5f), -6, 0); // x��ǥ �����ϰ� ����
            timer = 0;
            Destroy(newtree, 6.0f); // 6�� �ڿ� pipe ����
        }
    }
}