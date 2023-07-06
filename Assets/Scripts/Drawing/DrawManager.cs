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
    private Vector2 mousePos;
    private bool drawing;
    private bool GameOver = false;

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
            GameOver = true;
            _outline.SetActive(false);
        }
    }

    void Start()
    {
        _cam = Camera.main;
        Time.timeScale = 0;
    }

    private void Update()
    {
        mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        if (NumberScript.CanDraw && !GameOver) Time.timeScale = 1f;
        if (Input.GetMouseButtonDown(0))
        {
            _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity);
        }
        drawing = Input.GetMouseButton(0) ? true : false;
    }

    void FixedUpdate()
    {
        if (drawing && LineCollider.CanDrawOut) _currentLine.SetPosition(mousePos);
    }
}