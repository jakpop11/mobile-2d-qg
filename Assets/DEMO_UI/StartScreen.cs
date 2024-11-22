using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;


public class StartScreen : BaseUIScreen
{
    [SerializeField] Sprite startBtnBackground;
    [SerializeField] Sprite exitBtnBackground;

    protected override IEnumerator Generate()
    {
        // IEnumerator provides a way to animate UI
        yield return null;

        VisualElement root = document.rootVisualElement;

        // Clear document to prevent displaying old UI in Editor
        root.Clear();

        root.styleSheets.Add(styleSheet);

        var label = Create<Label>("large-text");
        label.text = "Get ready!";
        root.Add(label);


        var startBtn = Create<Button>();
        startBtn.text = "Start";
        startBtn.style.backgroundImage = new StyleBackground(startBtnBackground);
        root.Add(startBtn);


        var exitBtn = Create<Button>("small-button");
        exitBtn.text = "Exit";
        exitBtn.style.backgroundImage = new StyleBackground(exitBtnBackground);
        root.Add(exitBtn);

    }

}
