using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class mine_bar : MonoBehaviour
{

    public static event Action bouns;
    public static event Action give_rock;


    private float spring = 0;
    public float speed = 3;
    public float power = 1;
    public Image filling;
    public float sec = 1;
    private float fill = 1;

    void LateStart()
    {
        filling = GetComponent<Image>();
    }



    void Update()
    {
        ///spring
        if (spring > 0)
        {
            var SH = -Mathf.Sin(spring) * power;
            transform.localScale = new Vector3(1 - SH / 1.428f, 1 + SH / 1.428f, 1 - SH);
            spring -= Time.deltaTime * speed;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        ///log_bar
        filling.fillAmount = fill;
        fill += Time.deltaTime / sec;
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (fill > 1f)
            {
                give_rock?.Invoke();
                bouns?.Invoke();
                spring = 3.14f * 2;
                fill = 0;
            }
        }
    }
}
