using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    [SerializeField] private GameObject panel;

    [SerializeField] private List<GameObject> nodes = new List<GameObject>();


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        foreach (GameObject node in nodes)
        {
            GameObject newNode = Instantiate(node);
            newNode.transform.SetParent(panel.transform, false);
        }
    }
}

public class GridNode
{
    private StatType statType;
    private Image icon;
    private bool isUnlocked = false;
    private List<GridEdge> edges = new List<GridEdge>();

    public GridNode(StatType statType, Image icon)
    {
        this.statType = statType;
        this.icon = icon;
    }

    public GridNode(GridNodeData data)
    {
        statType = data.statType;
        icon = data.icon;
    }

    public void AddEdge(GridEdge edge)
    {
        edges.Add(edge);
    }
}

public class GridEdge
{
    private GridNode fromNode;
    private GridNode toNode;

    public GridEdge(GridNode fromNode, GridNode toNode)
    { 
        this.fromNode = fromNode;
        this.toNode = toNode; 
    }
}
