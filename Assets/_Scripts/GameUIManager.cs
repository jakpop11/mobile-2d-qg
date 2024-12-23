using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
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
    static string restartExitButtonName = "restart-exit-button";

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
    Button restartExitButton;

    // Events
    public UnityEvent StartButtonClicked;
    public UnityEvent ExitButtonClicked;
    public UnityEvent RestartButtonClicked;


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
        restartExitButton = root.Q<Button>(restartExitButtonName);
    }


    void SubscribeToEvents()
    {
        //startButton.RegisterCallback<Input.ButtonClickEvent>(myFunction);

        startButton.clicked += OnStartClicked;
        exitButton.clicked += OnExitClicked;
        restartButton.clicked += OnRestartClicked;
        restartExitButton.clicked += OnExitClicked;
    }

    void UnsubscribeToEvents()
    {
        //startButton.UnregisterCallback<Input.ButtonClickEvent>(myFunction);

        startButton.clicked -= OnStartClicked;
        exitButton.clicked -= OnExitClicked;
        restartButton.clicked -= OnRestartClicked;
        restartExitButton.clicked -= OnExitClicked;
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
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }

    void OnRestartClicked()
    {
        RestartButtonClicked?.Invoke();

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
