using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;//장애물오브젝트들
    private bool stepped = false;

    private void OnEnable()
    {
        stepped = false;
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    void OnCollisionEnterZD(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            //GameManager.instance.AddScore(1);
        }
    }


}