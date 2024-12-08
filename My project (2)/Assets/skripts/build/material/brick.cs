using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brick : MonoBehaviour
{
    void OnEnable()
    {
        storage_bar.BrickClaim += sad;
        bear_move.Pnormal += sad;
    }
    void OnDisable()
    {
        storage_bar.BrickClaim -= sad;
        bear_move.Pnormal -= sad;
    }
    void sad()
    {
        Destroy(gameObject);
    }
}
