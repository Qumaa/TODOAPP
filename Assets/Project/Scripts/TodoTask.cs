using System;
using UnityEngine;
using UnityEngine.UIElements;

public class TodoTask
{
    private const string _TASK_DOCUMENT_PATH = "Task";
    private const string _TASK_LABEL_NAME = "task-label";
    private const string _TASK_REMOVE_BUTTON = "remove-button";
    private const string _TASK_COMPLETED_TOGGLE_NAME = "completed-toggle";
    private const string _TASK_COMPLETED_STYLE = "completed-task";
    private const string _TASK_UNCOMPLETED_STYLE = "uncompleted-task";
    private const string _TASK_CONTAINER_NAME = "task-container";
    private const string _TASK_CONTAINER_STYLE = "template-container";

    private readonly VisualElement _taskContainer;

    public TemplateContainer Container { get; }

    public event Action OnRemoved;

    public TodoTask(string prompt)
    {
        var document = Resources.Load<VisualTreeAsset>(_TASK_DOCUMENT_PATH);

        Container = document.CloneTree();
        Container.AddToClassList(_TASK_CONTAINER_STYLE);
        _taskContainer = Container.Q(_TASK_CONTAINER_NAME);

        Container.Q<Label>(_TASK_LABEL_NAME).text = prompt;
        Container.Q<Button>(_TASK_REMOVE_BUTTON).clickable.clicked += () => OnRemoved?.Invoke();

        var toggle = Container.Q<Toggle>(_TASK_COMPLETED_TOGGLE_NAME);
        toggle.RegisterCallback<ClickEvent>(evt => ToggleCompleted(toggle.value));
    }

    private void ToggleCompleted(bool completed)
    {
        if (completed)
        {
            _taskContainer.AddToClassList(_TASK_COMPLETED_STYLE);
            _taskContainer.RemoveFromClassList(_TASK_UNCOMPLETED_STYLE);
        }
        else
        {
            _taskContainer.AddToClassList(_TASK_UNCOMPLETED_STYLE);
            _taskContainer.RemoveFromClassList(_TASK_COMPLETED_STYLE);
        }
    }
}