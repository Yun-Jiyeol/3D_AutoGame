using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    public void SettingDamage(float damage)
    {
        gameObject.GetComponent<TextMeshPro>().text = damage.ToString();

        StartCoroutine(DamageMove());
    }

    IEnumerator DamageMove()
    {
        while (gameObject.GetComponent<RectTransform>().transform.localPosition.y <= 6)
        {
            gameObject.GetComponent<RectTransform>().transform.localPosition += new Vector3(0,2,0) * Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);  
    }
}
