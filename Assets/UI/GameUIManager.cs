using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class GameUIManager : MonoBehaviour
{
    // Visual Elements' names
    static string startScreenName = "StartScreen";
    static string startButtonName = "start-button";
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
    public static event Action StartButtonClicked;
    public static event Action ExitButtonClicked;
    public static event Action RestartButtonClicked;


    void Awake()
    {
        document = GetComponent<UIDocument>();
    }

    void Start()
    {
        GetVisualElements();
        SubscribeToEvents();
        Initialize();
    }


    void GetVisualElements()
    {
        root = document.rootVisualElement;

        startScreen = root.Q<VisualElement>(startScreenName);
        startButton = root.Q<Button>(startButtonName);
        exitButton = root.Q<Button>(exitButtonName);

        gameplayScreen = root.Q<VisualElement>(gameplayScreenName);
        scoreLabel = root.Q<Label>(scoreLabelName);

        restartScreen = root.Q<VisualElement>(restartScreenName);
        restartButton = root.Q<Button>(restartButtonName);
    }


    void SubscribeToEvents()
    {
        //startButton.RegisterCallback<Input.ButtonClickEvent>(myFunction);

        startButton.clicked += OnStartClicked;
        exitButton.clicked += ExitButtonClicked;
        restartButton.clicked += RestartButtonClicked;
    }

    void UnsubscribeToEvents()
    {
        //startButton.UnregisterCallback<Input.ButtonClickEvent>(myFunction);

        startButton.clicked -= OnStartClicked;
        exitButton.clicked -= ExitButtonClicked;
        restartButton.clicked -= RestartButtonClicked;
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



    void ShowScreen(VisualElement screen)
    {
        screen.style.display = DisplayStyle.Flex;
    }

    void HideScreen(VisualElement screen)
    {
        screen.style.display = DisplayStyle.None;
    }


    void OnDestroy()
    {
        UnsubscribeToEvents();
    }
}
