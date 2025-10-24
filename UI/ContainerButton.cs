using TMPro;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UI;

public abstract class ContainerButton<T> : MonoBehaviour
{
    protected Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    protected void SetButtonText(string text)
    {
        _button.GetComponentInChildren<TMP_Text>().text = text;
    }

    public abstract void Setup(T entry);
}
