using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


public class GameUIManager : MonoBehaviour
{
    // Visual Elements' names
    static string startScreenName = "StartScreen";
    static string startButtonName = "StartButton";
    static string exitButtonName = "exit-button";

    static string gameplayScreenName = "GameplayScreen";
    static string scoreLabelName = "score-label";

    static string restartScreenName = "RestartScreen";
    static string restartButtonName = "restart-button";
    //static string exitButtonName = "exit-button";

    // Visual Elements
    UIDocument document;
    VisualElement root;

    VisualElement startScreen;
    Button startButton;
    Button exitButton;

    VisualElement gameplayScreen;
    Label scoreLabel;

    VisualElement restartScreen;
    Button restartButton;
    //Button exitButton;

    // Events
    public static UnityEvent StartButtonClicked;
    public static UnityEvent ExitButtonClicked;
    public static UnityEvent RestartButtonClicked;


    void Awake()
    {
        document = GetComponent<UIDocument>();
        GetVisualElements();

    }

    void OnEnable()
    {
        SubscribeToEvents();
    }

    private void OnDisable()
    {
        UnsubscribeToEvents();
    }

    void Start()
    {
        Initialize();
    }


    void GetVisualElements()
    {
        root = document.rootVisualElement;

        startScreen = root.Q(startScreenName);
        startButton = root.Q<Button>(startButtonName);
        exitButton = root.Q<Button>(exitButtonName);

        gameplayScreen = root.Q(gameplayScreenName);
        scoreLabel = root.Q<Label>(scoreLabelName);

        restartScreen = root.Q(restartScreenName);
        restartButton = root.Q<Button>(restartButtonName);
    }


    void SubscribeToEvents()
    {
        //startButton.RegisterCallback<Input.ButtonClickEvent>(myFunction);

        startButton.clicked += OnStartClicked;
        exitButton.clicked += OnExitClicked;
        restartButton.clicked += OnRestartClicked;
    }

    void UnsubscribeToEvents()
    {
        //startButton.UnregisterCallback<Input.ButtonClickEvent>(myFunction);

        startButton.clicked -= OnStartClicked;
        exitButton.clicked -= OnExitClicked;
        restartButton.clicked -= OnRestartClicked;
    }

    void Initialize()
    {
        ShowScreen(startScreen);
        ShowScreen(gameplayScreen);
        HideScreen(restartScreen);
    }


    // Events Callbacks?
    void OnStartClicked()
    {
        HideScreen(startScreen);

        StartButtonClicked?.Invoke();
    }

    void OnExitClicked()
    {
        Debug.Log("Quitting");
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

    void OnRestartClicked()
    {

    }


    // Called externally
    public void OnGameOver()
    {
        ShowScreen(restartScreen);
    }

    public void UpdateScoreLabel(int score)
    {
        if (!scoreLabel.visible) return;
        scoreLabel.text = score.ToString();
    }


    void ShowScreen(VisualElement screen)
    {
        screen.style.display = DisplayStyle.Flex;
    }

    void HideScreen(VisualElement screen)
    {
        screen.style.display = DisplayStyle.None;
    }


    //void OnDestroy()
    //{
    //    UnsubscribeToEvents();
    //}
}
