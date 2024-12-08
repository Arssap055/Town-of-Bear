using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class storage_bar : MonoBehaviour
{

    public TMP_Text woodT;
    public TMP_Text brickT;
    public static event Action WoodClaim;
    public static event Action BrickClaim;

    private float spring = 0;
    public float speed = 3;
    public float power = 1;
    public int wood = 0;
    public int brick = 0;

    void Update()
    {
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
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player_wood")
        {
            WoodClaim?.Invoke();
            spring = 3.14f * 2;
            wood += 1;
            woodT.text = wood.ToString();
            examination();
        }
        if (collision.gameObject.tag == "Player_brick")
        {
            BrickClaim?.Invoke();
            spring = 3.14f * 2;
            brick += 1;
            brickT.text = brick.ToString();
            examination();
        }
    }
    void examination()
    {
        if ((brick >= 5) || (wood >= 5))
        {
            SceneManager.LoadScene("start_menu");
        }
    }
}
