using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonContainer<T> : MonoBehaviour where T : IHasName
{
    public T _entry;
    public Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void Setup(T entry) 
    {
        _entry = entry;
        SetButtonText(entry.Name);
    }

    protected void SetButtonText(string text)
    {
        _button.GetComponentInChildren<TMP_Text>().text = text;
    }

    public T GetEntry()
    {
        return _entry;
    }
}
