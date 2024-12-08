using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class paus : MonoBehaviour
{
    private bool fase = true;
    private int buttin_fase = 0;
    public GameObject conitinion;
    public GameObject exit;
    public GameObject panel;
    public GameObject point;

    void Start()
    {
        conitinion.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        panel.gameObject.SetActive(false);
        point.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(fase);
            if (fase)
            {
                fase = false;
                Time.timeScale = 0;
                conitinion.gameObject.SetActive(true);
                exit.gameObject.SetActive(true);
                panel.gameObject.SetActive(true);
                point.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                fase = true;
                conitinion.gameObject.SetActive(false);
                exit.gameObject.SetActive(false);
                panel.gameObject.SetActive(false);
                point.gameObject.SetActive(false);
            }
            
        }
        if (!fase)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                buttin_fase += 1;
                but();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                buttin_fase -= 1;
                but();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (buttin_fase == 1)
                {
                    conitinion.gameObject.SetActive(false);
                    exit.gameObject.SetActive(false);
                    panel.gameObject.SetActive(false);
                    point.gameObject.SetActive(false);
                    Time.timeScale = 1;
                    fase = true;
                }
                else
                {
                    SceneManager.LoadScene("start_menu");
                    Time.timeScale = 1;
                }
            }

        }
    }
    void but()
    {
        if (buttin_fase == 2)
        {
            buttin_fase = 0;
        }
        if (buttin_fase == -1)
        {
            buttin_fase = 1;
        }
        if (buttin_fase == 1)
        {
            point.transform.position = conitinion.transform.position;
        }
        else
        {
            point.transform.position = exit.transform.position;
        }
    }

}
