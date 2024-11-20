using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseUIScreen : MonoBehaviour
{
    [SerializeField] protected UIDocument document;
    [SerializeField] protected StyleSheet styleSheet;


    protected virtual void Start()
    {
        StartCoroutine(Generate());
    }

    /// <summary>
    /// Provides a way to display UI in Editor
    /// </summary>
    protected virtual void OnValidate()
    {
        // Prevents from generating UI multiple times
        if (Application.isPlaying) return;

        StartCoroutine(Generate());

    }

    /// <summary>
    /// Override this
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator Generate()
    {
        // IEnumerator provides a way to animate UI
        yield return null;

    }

    /// <summary>
    /// Creates base VisualElement with specified uss classes
    /// </summary>
    /// <param name="ussClassNames"></param>
    /// <returns></returns>
    protected VisualElement Create(params string[] ussClassNames)
    {
        return Create<VisualElement>(ussClassNames);
    }

    /// <summary>
    /// Generic method to create specified VisualElement with uss classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ussClassNames"></param>
    /// <returns></returns>
    protected T Create<T>(params string[] ussClassNames) where T : VisualElement, new()
    {
        var element = new T();
        foreach (var ussClassName in ussClassNames)
        {
            element.AddToClassList(ussClassName);
        }

        return element;
    }
}
