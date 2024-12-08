using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wood : MonoBehaviour
{
    void OnEnable()
    {
        storage_bar.WoodClaim += sad;
        bear_move.Pnormal += sad;
    }
    void OnDisable()
    {
        storage_bar.WoodClaim -= sad;
        bear_move.Pnormal -= sad;
    }
    void sad()
    {
        Destroy(gameObject);
    }
}
