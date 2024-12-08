using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class stonecutter_bar : MonoBehaviour
{
    public static event Action PickUpRock;
    public static event Action PickDownBrick;
    public static event Action bouns;

    private float spring = 0;
    public float speed = 3;
    public float power = 1;
    public Image filling;
    public float sec = 1;
    public float fill = 0;
    private int fase = 0;

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
        if (fase == 0)
        {
            if (collision.gameObject.tag == "Player_rock")
            {
                if (fill > 1f)
                {
                    bouns?.Invoke();
                    PickUpRock?.Invoke();
                    spring = 3.14f * 2;
                    fill = 0;
                    fase = 1;
                }
            }
        }
        else
        {
            if (collision.gameObject.tag == "Player")
            {
                if (fill > 1f)
                {
                    bouns?.Invoke();
                    PickDownBrick?.Invoke();
                    spring = 3.14f * 2;
                    fill = 1;
                    fase = 0;
                }
            }
        }
    }
}
