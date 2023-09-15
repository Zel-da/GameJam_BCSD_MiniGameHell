using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public string enemyName;
    public float maxShotDelay;
    public float curShotDelay;
    public GameObject bulletObjA;
    public GameObject bulletobjB;
    public GameObject players;

    public Transform player;
    public float followSpeed = 0.1f;
    public float randomMoveRange = 0.1f;

    private void Update()
    {
        // 플레이어를 따라가는 코드
        Vector3 targetPosition = new Vector3(transform.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // 랜덤한 x, y 이동
        float randomX = Random.Range(-randomMoveRange, randomMoveRange);
        float randomY = Random.Range(-randomMoveRange, randomMoveRange);
        transform.position += new Vector3(randomX, randomY, 0) * Time.deltaTime;

        Fire();
        Reload();
    }

    void Fire()
    {
        if (curShotDelay < maxShotDelay)
            return;
        if(enemyName == "S")
        {
            GameObject bullet = Instantiate(bulletObjA, transform.position, transform.rotation);
            Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            Vector3 dirVec = player.transform.position - transform.position;
            rigid.AddForce(Vector2.left * 8, ForceMode2D.Impulse);
        }


        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
}

