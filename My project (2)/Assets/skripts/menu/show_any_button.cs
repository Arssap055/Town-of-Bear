using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_any_button : MonoBehaviour
{

    public GameObject tekst;
    public GameObject panel;
    void Start()
    {
        Time.timeScale = 0;
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            tekst.gameObject.SetActive(false);
            panel.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
