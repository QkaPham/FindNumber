using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryPanel : MonoBehaviour
{
    [SerializeField] private Button NewGameButton;

    private void Awake()
    {
        NewGameButton.onClick.AddListener(OnNewGameButtonClick);
    }

    private void OnNewGameButtonClick()
    {
        Debug.Log("Start New Game");    
    }
}
