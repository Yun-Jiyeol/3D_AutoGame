using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteract : MonoBehaviour
{
    public GameObject UIgameobject;
    Coroutine uicoroutine;
    bool isOn = false;

    private void Start()
    {
        UIgameobject.SetActive(false);
    }

    public void OpenUI()
    {
        if (isOn) return;
        isOn = true;

        UIgameobject.SetActive(true);
        transform.localScale = new Vector3(0,0,1);

        if (uicoroutine != null) StopCoroutine(uicoroutine);
        uicoroutine = StartCoroutine(OpenUICoroutine());
    }

    IEnumerator OpenUICoroutine()
    {
        while(transform.localScale.x < 1)
        {
            transform.localScale += new Vector3(1f, 1f, 0 )* 3f * Time.deltaTime;
            yield return null;
        }
    }

    public void CloseUI()
    {
        if (!isOn) return;
        isOn = false;

        transform.localScale = Vector3.one;

        if (uicoroutine != null) StopCoroutine(uicoroutine);
        uicoroutine = StartCoroutine(CloseUICoroutine());
    }
    IEnumerator CloseUICoroutine()
    {
        while (transform.localScale.x >= 0)
        {
            transform.localScale -= new Vector3(1f,  1f, 0) * 3f * Time.deltaTime;
            yield return null;
        }

        UIgameobject.SetActive(false);
    }
}
