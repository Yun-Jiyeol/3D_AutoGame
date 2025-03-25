using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<ItemScript> Head;
    public List<ItemScript> Body;
    public List<ItemScript> Boots;
    public List<ItemScript> Weapon;

    private void Start()
    {
        GameManager.instance.itemManager = this;
    }
}
