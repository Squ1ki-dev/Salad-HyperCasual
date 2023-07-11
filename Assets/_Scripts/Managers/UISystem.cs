using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISystem : Singleton<UISystem>
{
    [SerializeField] private GameObject startPanel, gamePanel, winPanel, losePanel;
    //[SerializeField] private TMP_Text scoreText,totalScore;

    //private GameObject scoreParent;

    [SerializeField] Text levelText;

    protected override void Awake()
    {
        base.Awake();

        EventManager.OnBeginGame += OnBeginPanelState;
        EventManager.OnWin += OnWinPanel;
        EventManager.OnLose += OnLosePanel;
    }

    private void Start() {
        levelText.GetComponent<Text>().text = Tags.Level + " " + (PlayerPrefs.GetInt(Tags.Level) +1).ToString();
    }

    private void OnBeginPanelState()
    {
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        //winPanel.SetActive(false);
        //losePanel.SetActive(false);
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        GameStateEvent.Fire_OnChangeGameState(State.Play);
    }

    public void OnWinPanel() => winPanel.SetActive(true);
    public void OnLosePanel() => losePanel.SetActive(true);

    private void OnDisable()
    {
        EventManager.OnBeginGame -= OnBeginPanelState;
        EventManager.OnWin -= OnWinPanel;
        EventManager.OnLose -= OnLosePanel;
    }
}