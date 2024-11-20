using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UIView
{
    protected VisualElement rootElement;

    public VisualElement Root => rootElement;
    public bool IsHidden => rootElement.style.display == DisplayStyle.None;


    public UIView(VisualElement topElement)
    {
        rootElement = topElement ?? throw new ArgumentNullException(nameof(topElement));
        Initialize();
    }

    public virtual void Initialize()
    {
        // Hide if should be hidden on awake

        SetVisualElements();
        RegisterButtonCallbacks();
    }

    /// <summary>
    /// Override this
    /// </summary>
    protected virtual void SetVisualElements()
    {
        rootElement.style.flexGrow = 1;
    }

    /// <summary>
    /// Override this
    /// </summary>
    protected virtual void RegisterButtonCallbacks()
    {

    }

    public virtual void Show()
    {
        rootElement.style.display = DisplayStyle.Flex;
    }

    public virtual void Hide()
    {
        rootElement.style.display = DisplayStyle.None;
    }

    // Dispose method to unregisters any callbacks or event handlers?

}
