using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class Reward : MonoBehaviour
{
    private List<ItemScript> rewards = new List<ItemScript>();

    public GameObject SpawnPosition;

    public GameObject Slot;
    private List<GameObject> slots = new List<GameObject>();

    public void CheckingRewards(List<ItemScript> Gatcha)
    {
        foreach(ItemScript items in Gatcha)
        {
            GameObject go = Instantiate(Slot);
            go.GetComponent<Slot>().Setting(items);
            go.GetComponent<Button>().enabled = false;
            go.transform.SetParent(SpawnPosition.transform);
            slots.Add(go);
        }
    }

    public void ClickEscapeBtn()
    {
        DeleteAllSlots();

        gameObject.SetActive(false);
    }

    void DeleteAllSlots()
    {
        foreach(GameObject item in slots)
        {
            Destroy(item);
        }
        slots.Clear();
    }
}
