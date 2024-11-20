using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIScreen : BaseUIScreen
{


    protected override IEnumerator Generate()
    {
        // IEnumerator provides a way to animate UI
        yield return null;

        VisualElement root = document.rootVisualElement;

        // Clear document to prevent displaying old UI in Editor
        root.Clear();

        root.styleSheets.Add(styleSheet);

        UIView startView = new StartView(new VisualElement());
        root.Add(startView.Root);
    }
}
