using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartView : UIView
{
    

    public StartView(VisualElement topElement) : base(topElement)
    {
        // Subscribe to events

    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        var label = UIHelpers.Create<Label>("large-text");
        label.text = "Get ready!";
        rootElement.Add(label);


        var startBtn = UIHelpers.Create<Button>();
        startBtn.text = "Start";
        rootElement.Add(startBtn);


        var exitBtn = UIHelpers.Create<Button>("small-button");
        exitBtn.text = "Exit";
        rootElement.Add(exitBtn);
    }

}
