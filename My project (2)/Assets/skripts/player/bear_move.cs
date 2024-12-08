using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class bear_move : MonoBehaviour
{
    Rigidbody Rb;

    public Transform Log;
    public Transform wood;
    public Transform rock;
    public Transform brick;
    public Transform Parent;

    [Header("Move")]
    public float acceleration = 0.12f;
    public float maxSpeed = 1.0f;
    public float moveX = 0;
    private float moveZ = 0;
    new Vector3 moveVector = new Vector3 (0, 0, 0);

    [Header("event oxygen")]

    public Image oxygen_bar;
    public bool oxygen_starvation = false;
    private float oxygen_sec_M = 5;
    private float oxygen_sec = 0;
    private float oxygen_sec2 = 0;
    private float oxygen_recharge = 5;

    [Header("earth quakes")]

    public bool earthquakes_starvation = false;
    public float fall_strange = 0;
    private float eqtime = 0;
    private float eqtime2 = 0;
    public static event Action Pnormal;

    [Header("burning")]

    public bool burnig = false;
    public static event Action<bool> burned;




    void OnEnable()
    {
        storage_bar.WoodClaim += normal;
        storage_bar.BrickClaim += normal;
        stonecutter_bar.PickUpRock += normal;

        log_bar.bouns += reversal;
        wood_bar.bouns += reversal;
        mine_bar.bouns += reversal;
        stonecutter_bar.bouns += reversal;
        storage_bar.WoodClaim += reversal;
        storage_bar.BrickClaim += reversal;

        stonecutter_bar.PickDownBrick += give_brick;
        mine_bar.give_rock += give_rock;
        log_bar.bouns += give_log;
        wood_bar.PickUpTree += normal;
        wood_bar.PickDownWood += give_wood;

        earthquakes.fall += falled;
    }
    void OnDisable()
    {
        storage_bar.WoodClaim -= normal;
        storage_bar.BrickClaim -= normal;
        stonecutter_bar.PickUpRock -= normal;

        log_bar.bouns -= reversal;
        wood_bar.bouns -= reversal;
        mine_bar.bouns -= reversal;
        stonecutter_bar.bouns += reversal;
        storage_bar.WoodClaim -= reversal;
        storage_bar.BrickClaim -= reversal;

        stonecutter_bar.PickDownBrick -= give_brick;
        mine_bar.give_rock += give_rock;
        log_bar.bouns -= give_log;
        wood_bar.PickUpTree -= normal;
        wood_bar.PickDownWood -= give_wood;

        earthquakes.fall -= falled;
    }

    void Start()
    {

        burned?.Invoke(burnig);

        oxygen_sec = oxygen_sec_M;
        Rb = GetComponent<Rigidbody>();

    }

    void Update()
    {

        if((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
        {
            moveX += Input.GetAxis("Horizontal") * acceleration * 2 * Time.deltaTime;
            moveZ += Input.GetAxis("Vertical") * acceleration * 2 * Time.deltaTime;

            ///roation
            if (moveX != 0)
            {
                if (moveX > 0)
                {
                    transform.eulerAngles = new Vector3(0, 90, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 270, 0);
                }
            }
            if (moveZ != 0)
            {
                if (moveZ > 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
            }
        }

        moveX = Mathf.Round(moveX * 100) / 100;
        moveZ = Mathf.Round(moveZ * 100) / 100;



        if (moveX != 0)
            {
                if (moveX > 0)
                {
                    moveX -= acceleration * Time.deltaTime;
                    moveX = Mathf.Min(moveX, maxSpeed);
                }
                else
                {
                    moveX += acceleration * Time.deltaTime;
                    moveX = Mathf.Max(moveX, -maxSpeed);
                }
            }

        if (moveZ != 0)
            {
                if (moveZ > 0)
                {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveZ -= acceleration * Time.deltaTime;
                    moveZ = Mathf.Min(moveZ, maxSpeed);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0,180,0);
                    moveZ += acceleration * Time.deltaTime;
                    moveZ = Mathf.Max(moveZ, -maxSpeed);
                }
            }

        moveVector = new Vector3(moveX, 0, moveZ);

        if (oxygen_starvation)
        {
            if (oxygen_sec > 0)
            {
                oxygen_sec -= Time.deltaTime;
                oxygen_sec2 = (oxygen_sec / oxygen_sec_M) + 0.5f;
                oxygen_bar.fillAmount = oxygen_sec2 - 0.5f;
            }
            if (oxygen_sec2<= 1)
            {
                moveVector = new Vector3(moveX * oxygen_sec2, 0, moveZ * oxygen_sec2);
            }
        }

        if (earthquakes_starvation)
        {
            if (eqtime2 > 0)
            {
                eqtime2 -= Time.deltaTime;
                moveVector = new Vector3(0, 0, 0);
                
                
            }
        }
        transform.Translate(moveVector * Time.deltaTime, Space.World);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pnormal?.Invoke();
            gameObject.tag = "Player";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "oxygen_save")
        {
            if (oxygen_sec < oxygen_sec_M)
            {
                oxygen_sec += Time.deltaTime*oxygen_recharge;
            }
        }
    }

    void reversal()
    {
        moveZ *= -1;
        moveX *= -1;
    }

    void give_log()
    {
        gameObject.tag = "Player_log";
        var rotation_s = transform.rotation.y;
        Instantiate(Log, new Vector3(transform.position.x + (Mathf.Sin(rotation_s) * 0.5f), transform.position.y, transform.position.z + (Mathf.Sin(rotation_s) * 0.5f)), Quaternion.identity, Parent);
    }

    void give_wood()
    {
        gameObject.tag = "Player_wood";
        var rotation_s = transform.rotation.y;
        Instantiate(wood, new Vector3(transform.position.x + (Mathf.Sin(rotation_s) * 0.5f), transform.position.y  + 0.5f, transform.position.z + (Mathf.Sin(rotation_s) * 0.5f)), Quaternion.identity, Parent);
    }

    void normal()
    {
        gameObject.tag = "Player";
    }

    void give_rock()
    {
    gameObject.tag = "Player_rock";
        var rotation_s = transform.rotation.y;
        Instantiate(rock, new Vector3(transform.position.x + (Mathf.Sin(rotation_s) * 0.5f), transform.position.y , transform.position.z + (Mathf.Sin(rotation_s) * 0.5f)), Quaternion.identity, Parent);
    }

    void give_brick()
    {
        gameObject.tag = "Player_brick";
        var rotation_s = transform.rotation.y;
        Instantiate(brick, new Vector3(transform.position.x + (Mathf.Sin(rotation_s) * 0.5f), transform.position.y, transform.position.z + (Mathf.Sin(rotation_s)  *  0.5f)), Quaternion.identity, Parent);
    }

    void falled(float eqtime)
    { 
        if (earthquakes_starvation)
        {
            eqtime2 = eqtime;
            Rb.AddForce(transform.up * fall_strange);
            Pnormal?.Invoke();
            gameObject.tag = "Player";
        }
    }
}
