using System;
using UnityEngine;
using UnityEngine.UIElements;

public class TodoTask
{
    private const string _TASK_DOCUMENT_PATH = "Task";
    private const string _TASK_LABEL_NAME = "task-label";
    private const string _TASK_REMOVE_BUTTON = "remove-button";
    
    public TemplateContainer Container { get; }

    public event Action OnRemoved;

    public TodoTask(string prompt)
    {
        var document = Resources.Load<VisualTreeAsset>(_TASK_DOCUMENT_PATH);

        Container = document.CloneTree();
        
        Container.Q<Label>(_TASK_LABEL_NAME).text = prompt;
        Container.Q<Button>(_TASK_REMOVE_BUTTON).clickable.clicked += () => OnRemoved?.Invoke();
    }
}