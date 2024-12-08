using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    void OnEnable()
    {
        stonecutter_bar.PickUpRock += sad;
        bear_move.Pnormal += sad;
    }
    void OnDisable()
    {
        stonecutter_bar.PickUpRock -= sad;
        bear_move.Pnormal -= sad;
    }
    void sad()
    {
        Destroy(gameObject);
    }
}
