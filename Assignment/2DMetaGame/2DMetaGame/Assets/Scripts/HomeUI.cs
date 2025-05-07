using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeUI : BaseUI
{
    Button startButton;
    Button exitButton;

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        startButton = transform.Find("StartButton").GetComponent<Button>();
        exitButton = transform.Find("ExitButton").GetComponent <Button>();

        startButton.onClick.AddListener(onClickStartButton);
        exitButton.onClick.AddListener(onClickExitButton);
    }

    void onClickStartButton()
    {
        uiManager.OnClickStart();
    }

    void onClickExitButton()
    {
        SceneManager.LoadScene("TownScene");
    }
}
