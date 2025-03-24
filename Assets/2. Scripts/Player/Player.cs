using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.player = this;
    }
}
