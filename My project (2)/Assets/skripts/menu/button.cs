using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class button : MonoBehaviour
{
    public static event Action show_level;
    public GameObject start_button;
    public GameObject exit_button;

    public GameObject point;

    public int fase =  1;
    void Start()
    {
        point.gameObject.SetActive(false);
    }
    void Update()

    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            fase += 1;
            but();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            fase -= 1;
            but();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fase == 0)
            {
                Application.Quit();       
            }
            else
            {
                point.gameObject.SetActive(true);
                gameObject.SetActive(false);
                show_level?.Invoke();
            }
        }

    }
    void but()
    {
        if (fase == 2)
        {
            fase = 0;
        }
        if (fase == -1)
        {
            fase = 1;
        }
        if (fase == 1)
        {
            transform.position = start_button.transform.position;
        }
        else
        {
            transform.position = exit_button.transform.position;
        }

    }
}
