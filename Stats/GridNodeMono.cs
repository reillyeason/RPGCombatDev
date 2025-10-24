using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridNodeMono : MonoBehaviour
{
    [SerializeField] GridNodeData data;
    private StatType statType;
    private Image icon;
    private bool isUnlocked = false;
    private List<GridEdge> edges = new List<GridEdge>();
    private int index;
    private Vector2 position;

    private void Awake()
    {
        this.statType = data.statType;
        this.icon = data.icon;
        gameObject.GetComponent<RectTransform>().localPosition = this.position;
    }

    public void AddEdge(GridEdge edge)
    {
        edges.Add(edge);
    }
}
