using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI Stage;

    public void OnClickGameOffBtn()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }

    public void SettingStageNum()
    {
        Stage.text = GameManager.instance.Stage.ToString();
    }

    public void ClickNextBtn()
    {
        if (GameManager.instance.MaxStage == GameManager.instance.Stage) return;

        GameManager.instance.ChangeStage(1);
    }

    public void ClickBackBtn()
    {
        if(GameManager.instance.Stage == 1) return;
        GameManager.instance.ChangeStage(-1);
    }
}
