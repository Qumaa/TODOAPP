using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TodoApp
{
    private List<TodoTask> _tasks;

    private readonly VisualElement _appContainer;
    
    #region Constants
    
    private const string _ADD_BUTTON_NAME = "add-button";
    private const string _INPUT_FIELD_NAME = "input-field";
    private const string _TASKS_CONTAINER_NAME = "tasks-container";

    #endregion
    
    public TodoApp(VisualElement appDocumentRootVisualElement)
    {
        appDocumentRootVisualElement.Q<Button>(_ADD_BUTTON_NAME).clickable.clicked += HandleAddButtonClicked;

        _tasks = new List<TodoTask>();
    }

    private void HandleAddButtonClicked()
    {
        var inputField = _appContainer.Q<TextField>();
        var input = inputField.value;

        AddTask(input);
    }

    private void AddTask(string prompt)
    {
        var task = new TodoTask(prompt, _appContainer.Q(_TASKS_CONTAINER_NAME));
        
        _tasks.Add(task);
    }
}

public class TodoTask
{
    private const string _TASK_DOCUMENT_PATH = "Task.uxml";
    private const string _TASK_LABEL_NAME = "task-label";
    private const string _TASK_REMOVE_BUTTON = "remove-button";

    public event Action OnRemoved;

    public TodoTask(string prompt, VisualElement container)
    {
        var document = Resources.Load(_TASK_DOCUMENT_PATH) as VisualTreeAsset;

        document.CloneTree(container);
    }
}