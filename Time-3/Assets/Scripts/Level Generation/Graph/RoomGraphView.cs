using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;

public class RoomGraphView : GraphView
{
    private readonly Vector2 nodeSize = new Vector2(150, 200);

    //Configura a janela do editor -Arthur
    public RoomGraphView()
    {
        SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
        
        this.AddManipulator(new ContentDragger());
        this.AddManipulator(new SelectionDragger());
        this.AddManipulator(new RectangleSelector());

        AddElement(GenerateEntryRoom());
    }

    //Verifica com quem o no pode se conectar -Arthur
    public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter adapter)
    {
        List<Port> compatiblePorts = new List<Port>();

        ports.ForEach((port) => 
        {
            if(startPort != port && startPort.node != port.node)
            {
                compatiblePorts.Add(port);
            }
        });

        return compatiblePorts;
    }

    //Cria uma nova saida para o no -Arthur
    private Port GeneratePort(RoomNode node, Direction portDirection, Port.Capacity capacity=Port.Capacity.Single)
    {
        return node.InstantiatePort(Orientation.Horizontal, portDirection, capacity, typeof(float));
    }

    //Gera o no de entrada -Arthur
    private RoomNode GenerateEntryRoom()
    {
        RoomNode node = new RoomNode
        {
            title = "Start",
            GUID =  System.Guid.NewGuid().ToString(),
            dialogueText = "Entrada",
            entryPoint = true
        };

        Button exit_button = new Button(() => {AddExitPort(node);});
        exit_button.text = "New exit";
        node.titleContainer.Add(exit_button);

        node.RefreshExpandedState();
        node.RefreshPorts();

        node.SetPosition(new Rect(100, 200, 100, 150));

        return node;
    }

    //Cria um novo no no grafo -Arthur
    public void CreateNode(string nodeName)
    {
        AddElement(CreateRoomNode(nodeName));
    }

    public RoomNode CreateRoomNode(string name)
    {
        RoomNode roomNode = new RoomNode
        {
            title = name,
            dialogueText = name,
            GUID = System.Guid.NewGuid().ToString(),
        };

        Port inputPort = GeneratePort(roomNode, Direction.Input, Port.Capacity.Multi);
        inputPort.name = "Input";
        roomNode.inputContainer.Add(inputPort);

        Button entry_button = new Button(() => {AddEntryPort(roomNode);});
        entry_button.text = "New entry";
        roomNode.titleContainer.Add(entry_button);

        Button exit_button = new Button(() => {AddExitPort(roomNode);});
        exit_button.text = "New exit";
        roomNode.titleContainer.Add(exit_button);

        roomNode.RefreshExpandedState();
        roomNode.RefreshPorts();

        roomNode.SetPosition(new Rect(Vector2.zero, nodeSize));

        return roomNode;
    }

    //Adiciona uma nova saida no no -Arthur
    private void AddExitPort(RoomNode node)
    {
        Port _port = GeneratePort(node, Direction.Output);

        int portCount = node.outputContainer.Query("connector").ToList().Count;
        _port.name = $"Choice {portCount}";

        node.outputContainer.Add(_port);

        node.RefreshExpandedState();
        node.RefreshPorts();
    }

    //Adiciona uma nova entrada ao no
    private void AddEntryPort(RoomNode node)
    {
        Port _port = GeneratePort(node, Direction.Input);

        int portCount = node.inputContainer.Query("connector").ToList().Count;
        _port.name = $"Choice {portCount}";

        node.inputContainer.Add(_port);

        node.RefreshExpandedState();
        node.RefreshPorts();
    }
}
    