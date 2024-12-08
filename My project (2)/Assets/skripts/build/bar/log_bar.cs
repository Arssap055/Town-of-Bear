using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class log_bar : MonoBehaviour
{
    public Transform Parent;
    public static event Action bouns;
    public static event Action give_log;

    [Header("burning")]
    private float fire = 0;
    public float burn_speed = 0;
    private bool burning = false;
    public Image burn_bar;
    public float burn_time = 0;
    public float burn_hp = 50;
    public Transform burn_partical;

    [Header("normal")]
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

    void OnEnable()
    {
        bear_move.burned += event_B;
    }
    void OnDisable()
    {
        bear_move.burned -= event_B;
    }
    void Update()
    {
//burn
        if (burning)
        {
            if (burn_time <=  0)
            {
                fire += 1;
                burn_time = UnityEngine.Random.Range(0, 1f);
                Debug.Log(burn_time);
                burn_bar.fillAmount = fire/burn_hp;
                if (fire / burn_hp * 2 == 1)
                {
                    Instantiate(burn_partical,transform.position, Quaternion.Euler(new Vector3(-90,0,0)), Parent);
                }
                if (fire == burn_hp)
                {
                    Destroy(gameObject);
                }
            }
            burn_time -= Time.deltaTime;
        }
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
                give_log?.Invoke();
                bouns?.Invoke();
                spring = 3.14f * 2;
                fill = 0;
            }
        }
    }

    void event_B(bool burn)
    {
        burning = burn;

    }
}