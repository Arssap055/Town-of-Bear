using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canera_menu : MonoBehaviour
{
    public GameObject bear;
    public float speed = 10;
    public float len = 10;
    private float angle = 0;
    public float hight = 1;
    public float y = 0;
    public float zeta = 0;
    void Start()
    {
        
    }

    void Update()
    {
        angle += Time.deltaTime * speed * (Mathf.Abs(Mathf.Sin(angle)) + 0.5f);
        transform.position = bear.transform.position + new Vector3(Mathf.Cos(angle) * len * zeta, y, Mathf.Sin(angle) * len);
    }
    void LateUpdate()
    {
        transform.LookAt(bear.transform.position + Vector3.up * hight);
    }
}
