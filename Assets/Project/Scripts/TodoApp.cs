using System.Collections.Generic;
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
        _appContainer = appDocumentRootVisualElement;
        
        _appContainer.Q<Button>(_ADD_BUTTON_NAME).clickable.clicked += HandleAddButtonClicked;

        _tasks = new List<TodoTask>();
    }

    private void HandleAddButtonClicked()
    {
        var inputField = _appContainer.Q<TextField>(_INPUT_FIELD_NAME);
        var input = inputField.value;
        
        if (string.IsNullOrEmpty(input))
            return;

        AddTask(input);
        inputField.value = "";
    }

    private void AddTask(string prompt)
    {
        var task = new TodoTask(prompt);
        
        _tasks.Add(task);
        task.OnRemoved += () => RemoveTask(task);
        _appContainer.Q(_TASKS_CONTAINER_NAME).Add(task.Container);
    }

    private void RemoveTask(TodoTask task)
    {
        task.Container.style.display = DisplayStyle.None;
        _tasks.Remove(task);
        _appContainer.Q(_TASKS_CONTAINER_NAME).Remove(task.Container);
    }
}