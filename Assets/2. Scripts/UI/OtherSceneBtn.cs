using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtherSceneBtn : MonoBehaviour
{
    public Button MenuButton;
    public Button MainButton;
    public Button InvenButton;
    public Button GatchaButton;

    private void Start()
    {
        MenuButton.onClick.AddListener(OnClickMenuButton);
        MainButton.onClick.AddListener(OnClickMainButton);
        InvenButton.onClick.AddListener(OnClickInvenButton);
        GatchaButton.onClick.AddListener(OnClickGatchaButton);
    }

    public void OnClickMenuButton()
    {
        GameManager.instance.uIManager.menu.gameObject.GetComponent<UIInteract>().OpenUI();
    }

    public void OnClickMainButton()
    {

    }
    public void OnClickInvenButton()
    {

    }
    public void OnClickGatchaButton()
    {

    }
}
