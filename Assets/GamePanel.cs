using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    public static GamePanel Instance;
    [SerializeField] private Number numberPrefabs;
    [SerializeField] private RectTransform spawnArea;
    [SerializeField] private int quantity;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private VictoryPanel victoryPanel;
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
            UpdateScore(score);
        }
    }


    private int currentFindNumber = 1;
    public int CurrentFindNumber
    {
        get
        {
            return currentFindNumber;
        }
        set
        {
            if (value > quantity)
            {
                Victory();
            }
            currentFindNumber = value;
        }
    }

    private void Awake()
    {
        Instance = this;


        var spawnPoints = CalculatePawnPoints();
        GenerateNumber(quantity, spawnPoints);
    }

    private List<Vector2> CalculatePawnPoints()
    {
        Vector3[] fourCorners = new Vector3[4];
        spawnArea.GetWorldCorners(fourCorners);
        Vector2 bottomLeft = fourCorners[0];
        Vector2 topRight = fourCorners[2];
        List<Vector2> spawnPoints = new List<Vector2>();
        float spacing = spawnArea.rect.height / 10f;
        for (float x = bottomLeft.x; x < topRight.x; x += spacing)
        {
            for (float y = bottomLeft.y; y < topRight.y; y += spacing)
            {
                spawnPoints.Add(new Vector2(x, y));
            }
        }
        return spawnPoints;
    }

    private void GenerateNumber(int quantity, List<Vector2> spawnPoints)
    {
        float spacing = spawnArea.rect.height / 30f;
        for (int i = 1; i <= quantity; i++)
        {
            var randPos = spawnPoints[Random.Range(0, spawnPoints.Count)];
            spawnPoints.Remove(randPos);

            var number = Instantiate(numberPrefabs, randPos + Random.insideUnitCircle * spacing, Quaternion.identity, transform);
            number.Init(i);
        }
    }

    private void Victory()
    {
        victoryPanel.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }
}
