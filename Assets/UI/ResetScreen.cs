using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ResetScreen : BaseUIScreen
{
    [SerializeField] Sprite restartBtnBackground;
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
        label.text = "Game over!";
        root.Add(label);


        var restartBtn = Create<Button>();
        restartBtn.text = "Restart";
        restartBtn.style.backgroundImage = new StyleBackground(restartBtnBackground);
        root.Add(restartBtn);


        var exitBtn = Create<Button>("small-button");
        exitBtn.text = "Exit";
        exitBtn.style.backgroundImage = new StyleBackground(exitBtnBackground);
        root.Add(exitBtn);

    }
}
