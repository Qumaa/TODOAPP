using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DemoRunner : MonoBehaviour
{
    [SerializeField] private UIDocument _appDocument;

    private TodoApp _app;

    private void Start()
    {
        _app = new TodoApp(_appDocument.rootVisualElement);
    }
}