using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : MonoBehaviour
{
    void OnEnable()
    {
        wood_bar.PickUpTree += sad;
        bear_move.Pnormal += sad;
    }
    void OnDisable()
    {
        wood_bar.PickUpTree -= sad;
        bear_move.Pnormal -= sad;
    }
    void sad()
    {
        Destroy(gameObject);
    }
}
