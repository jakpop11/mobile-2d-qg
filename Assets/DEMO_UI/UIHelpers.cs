using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class UIHelpers
{
    /// <summary>
    /// Creates base VisualElement with specified uss classes
    /// </summary>
    /// <param name="ussClassNames"></param>
    /// <returns></returns>
    public static VisualElement Create(params string[] ussClassNames)
    {
        return Create<VisualElement>(ussClassNames);
    }

    /// <summary>
    /// Generic method to create specified VisualElement with uss classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ussClassNames"></param>
    /// <returns></returns>
    public static T Create<T>(params string[] ussClassNames) where T : VisualElement, new()
    {
        var element = new T();
        foreach (var ussClassName in ussClassNames)
        {
            element.AddToClassList(ussClassName);
        }

        return element;
    }
}
