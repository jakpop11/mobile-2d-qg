using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;


public class MainMenuScreen : BaseUIScreen
{
    protected override IEnumerator Generate()
    {
        // IEnumerator provides a way to animate UI
        yield return null;

        VisualElement root = document.rootVisualElement;

        // Clear document to prevent displaying old UI in Editor
        root.Clear();

        root.styleSheets.Add(styleSheet);

        var label = Create<Label>();
        label.text = "Hello Game!";
        var label2 = Create<Label>("label-red");
        label2.text = "Hello World!";

        root.Add(label);
        root.Add(label2);
    }

}
