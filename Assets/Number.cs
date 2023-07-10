using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] public int number;

    private void Awake()
    {
        
    }

    public void Init(int number)
    {
        this.number = number;
        text.text = number.ToString();
        button.onClick.AddListener(OnNumberClick);
    }

    private void OnNumberClick()
    {
        if (GamePanel.Instance.CurrentFindNumber == number)
        {
            MarkFound();
            GamePanel.Instance.Score++;
            Debug.Log("Number " + number + " Found");
            GamePanel.Instance.CurrentFindNumber++;
        }
        else
        {
            Debug.Log("Please find " + GamePanel.Instance.CurrentFindNumber);
        }
    }

    private void MarkFound()
    {
        button.interactable = false;
    }
}
