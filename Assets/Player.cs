using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private Camera mainCamera;

    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            OnScoreChanged?.Invoke(score);
        }
    }
    private Number number;

    public static event Action<int> OnScoreChanged;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (!IsOwner) return;
        MouseFollow();
    }

    private void MouseFollow()
    {
        Vector2 mouseOnWorld = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseOnWorld;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Number>(out var number))
        {
            this.number = number;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        number = null;
    }

    private void OnClick()
    {
        if (number.number == GamePanel.Instance.CurrentFindNumber)
        {
            score++;
            GamePanel.Instance.CurrentFindNumber++;
        }
    }
}