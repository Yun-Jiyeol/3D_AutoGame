using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteract : MonoBehaviour
{
    public GameObject UIgameobject;
    Coroutine uicoroutine;

    public void OpenUI()
    {
        UIgameobject.SetActive(true);
        transform.localScale = Vector3.zero;

        if (uicoroutine != null) StopCoroutine(uicoroutine);
        uicoroutine = StartCoroutine(OpenUICoroutine());
    }

    IEnumerator OpenUICoroutine()
    {
        while(transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(0.1f, 0, 0.1f) * Time.deltaTime;
            yield return null;
        }
    }

    public void CloseUI()
    {
        transform.localScale = Vector3.one;

        if (uicoroutine != null) StopCoroutine(uicoroutine);
        uicoroutine = StartCoroutine(CloseUICoroutine());
    }
    IEnumerator CloseUICoroutine()
    {
        while (transform.localScale.x >= 0)
        {
            transform.localScale -= new Vector3(0.1f, 0, 0.1f) * Time.deltaTime;
            yield return null;
        }

        UIgameobject.SetActive(false);
    }
}
