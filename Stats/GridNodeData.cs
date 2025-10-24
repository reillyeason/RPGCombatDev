using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GridNodeData - ", menuName = "ScriptableObjects/GridNode")]
public class GridNodeData : ScriptableObject
{
    [SerializeField] public StatType statType;
    [SerializeField] public Image icon;

}
