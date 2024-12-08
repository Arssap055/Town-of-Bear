using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class earthquakes : MonoBehaviour
{
    public static event Action<float> fall;

    private float balance = 0f;
    private float aceleration = 0f;
    private float time = 0.1f;
    public float a_speed = 2f;
    public float Max_Min = 2;
    public float recoil = 200;

    public float Stime = 1;
    private float Shtime = 1;



    void Start()
    {
        time = Stime;
    }


    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            aceleration -= a_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            aceleration += a_speed * Time.deltaTime;
        }
        if(time > 1)
        {
            var r = UnityEngine.Random.Range(-1,1) * 2 + 1;
            aceleration = r * recoil;
            time = 0;
        }
        if (aceleration > 0)
        {
            aceleration = Mathf.Min(aceleration, Max_Min);
        }
        else
        {
            aceleration = Mathf.Max(aceleration, Max_Min * -1);
        }

        if (((balance > 135) || (balance < -135)) && (Shtime > Stime))
        {
            fall?.Invoke(Stime);          
            Shtime = 0;
            aceleration = 0;
            balance = 0;
        }
        if(Shtime < Stime)
        {
            aceleration = 0;
            balance = 0;
        }
        time += Time.deltaTime;
        Shtime += Time.deltaTime;

        balance += aceleration * Time.deltaTime;
        RectTransform rect = transform as RectTransform;
        rect.anchoredPosition = new Vector2(balance * 0.3f,0);
    }
}
