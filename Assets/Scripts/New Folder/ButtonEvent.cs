using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEvent : MonoBehaviour
{
    public GameObject imageObi;
    public Image myImage;

    void Start()
    {
        imageObi = GameObject.FindGameObjectWithTag("Untagged");
        myImage = imageObi.GetComponent<Image>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Func();
    }
    void Func()
    {
        myImage.sprite =
            Resources.Load<Sprite>("1000001034_detail_060-removebg-preview 1")
            as Sprite;
    }
}