using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor.Experimental.GraphView;

public class RoomGraph : EditorWindow
{
    private RoomGraphView graphView;

    [MenuItem("Graph/Room Graph")]
    public static void OpenGraphWindow()
    {
        var window = GetWindow<RoomGraph>();
        window.titleContent = new GUIContent("Room Graph");
    }

    private void OnEnable() 
    {
        ConstructGraphView();
        GenerateToolbar();
    }

    private void OnDisable() 
    {
        rootVisualElement.Remove(graphView);
    }

    private void ConstructGraphView()
    {
        graphView = new RoomGraphView
        {
            name = "Room Graph"
        };
        
        graphView.StretchToParentSize();
        rootVisualElement.Add(graphView);
    }

    private void GenerateToolbar()
    {
        Toolbar toolbar = new Toolbar();
        Button nodeCreationButton = new Button(() => {graphView.CreateNode("Room Node");});
        nodeCreationButton.text = "Create Node";
        toolbar.Add(nodeCreationButton);

        rootVisualElement.Add(toolbar);
    }
}
