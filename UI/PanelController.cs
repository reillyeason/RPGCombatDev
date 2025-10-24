using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;

public class PanelController : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject buttonPrefab;

    public void CreateButtons<T>(List<T> entries) where T : IHasName
    {
        foreach (var entry in entries)
        {
            GameObject button = CreateButton();
            ButtonContainer<T> buttonContainer = button.GetComponent<ButtonContainer<T>>();
            buttonContainer.Setup(entry);
        }
    }

    public void DeleteButtons()
    {
        Button[] buttons = gameObject.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            Destroy(button.gameObject);
        }
    }

    private GameObject CreateButton()
    {
        GameObject button = Instantiate(buttonPrefab);
        button.transform.SetParent(gameObject.transform, false);
        return button;
    }
}
