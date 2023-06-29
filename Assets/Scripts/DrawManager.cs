using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DrawManager : MonoBehaviour
{
    private Camera _cam;
    [SerializeField] private Line _linePrefab;
    [SerializeField] private TextMeshProUGUI _textToShow;
    [SerializeField] private GameObject _outline;

    public const float RESOLUTION = .1f;
    private Line _currentLine;

    private void OnEnable()
    {
        LineCollider.ShowText += OnShowText;
    }

    private void OnDisable()
    {
        LineCollider.ShowText -= OnShowText;
    }

    private void OnShowText(string textToShow)
    {
        _textToShow.text = textToShow;

        if (textToShow == "Yay! You drew it!")
        {
            _outline.SetActive(false);
            Time.timeScale = 0;
        }
    }

    void Start()
    {
        _cam = Camera.main;
    }


    void Update()
    {
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);

        if (Input.GetMouseButton(0)) _currentLine.SetPosition(mousePos);
    }
}