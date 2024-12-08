using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_asist : MonoBehaviour
{
    private float angle = 0;

    void OnEnable()
    {
        button.show_level += move;
    }
    void OnDisable()
    {
        button.show_level -= move;
    }
    void Update()
    {
        if (angle > 0)
        {
            angle -= Time.deltaTime * 2;
            transform.position += Vector3.left * 860 * Mathf.Sin(angle) * Time.deltaTime;
        }
    }
    void move()
    {
        angle = 3.14f;
    }
}
