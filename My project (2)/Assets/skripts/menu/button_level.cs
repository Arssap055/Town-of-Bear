using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class button_level : MonoBehaviour
{
    public static event Action show_level;
    public GameObject level_1;
    public GameObject level_2;
    public GameObject level_3;
    public GameObject level_4;
    public GameObject level_5;
    public GameObject level_6;
    public GameObject coming_soon;
    public GameObject coming_soon_T;
    private float time = 0;
    public int fase = 0;
    void Start()
    {
        coming_soon.gameObject.SetActive(false);
        coming_soon_T.gameObject.SetActive(false);
    }
    void Update()
    {
        time += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            fase -= 5;
            but();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            fase += 5;
            but();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            fase -= 1;
            but();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            fase += 1;
            but();
        }

        if ((Input.GetKeyDown(KeyCode.Space)) || (time == 1))
        {
            if (fase == 0)
            {
                SceneManager.LoadScene("level_1");
            }
            else
            {
                coming_soon.gameObject.SetActive(true);
                coming_soon_T.gameObject.SetActive(true);
            }

        }

    }
    void but()
    {
        if (fase >  6)
        {
            fase -= 5;
        }
        if (fase < 0)
        {
            fase += 5;
        }
        if (fase == 0)
        {
            transform.position = level_1.transform.position;
        }
        else  if (fase == 1)
        {
            transform.position = level_2.transform.position;
        }
        else if (fase == 2)
        {
            transform.position = level_3.transform.position;
        }
        else if (fase == 3)
        {
            transform.position = level_4.transform.position;
        }
        else if (fase == 4)
        {
            transform.position = level_5.transform.position;
        }
        else if (fase == 5)
        {
            transform.position = level_6.transform.position;
        }
    }
}
