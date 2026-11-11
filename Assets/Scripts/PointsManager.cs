using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public TMP_Text pointsText;
    public TMP_Text upgradeCostText;
    public TMP_Text upgradePointsPerSecondCostText;
    public TMP_Text pointsPerSecondText;
    public GameObject notEnoughPointsText;

    public int points = 0;

    public int pointsPerSecond;
    private int pointsPerClick = 1;
    private int upgradeCost = 1;
    public int upgradePointsPerSecondCost = 1;
    public float pointsAddInterval = 1;
    private float timer;

    void Start()
    {
        upgradeCostText.text = upgradeCost.ToString();
        pointsText.text = points.ToString();
        upgradePointsPerSecondCostText.text = upgradePointsPerSecondCost.ToString();
        pointsPerSecondText.text = pointsPerSecond.ToString();

        if (notEnoughPointsText != null)
        {
            notEnoughPointsText.SetActive(false);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > pointsAddInterval)
        {
            GeneratePoints(pointsPerSecond);
            timer = 0;
        }
    }

    public void GeneratePoints(int addedPoints)
    {
        points += addedPoints;
        pointsText.text = points.ToString();
    }

    public void GeneratePointsPerClick()
    {
        GeneratePoints(pointsPerClick);
    }

    public void Upgrade()
    {
        if (points >= upgradeCost)
        {
            points -= upgradeCost;
            pointsText.text = points.ToString();
            upgradeCost *= 2;
            upgradeCostText.text = upgradeCost.ToString();
            pointsPerClick += 1;
        }
        else
        {
            ShowNotEnoughPoints();
        }
    }

    public void UpgradePointsPerSecond()
    {
        if (points >= upgradePointsPerSecondCost)
        {
            points -= upgradePointsPerSecondCost;
            pointsText.text = points.ToString();
            AddPointsPerSecond(1);
            upgradePointsPerSecondCost *= 2;
            upgradePointsPerSecondCostText.text = upgradePointsPerSecondCost.ToString();
        }
        else
        {
            ShowNotEnoughPoints();
        }
    }

    public void AddPointsPerSecond(int amount)
    {
        pointsPerSecond += amount;
        pointsPerSecondText.text = pointsPerSecond.ToString();
    }

    public bool TrySpendPoints(int amount)
    {
        if (points >= amount)
        {
            points -= amount;
            pointsText.text = points.ToString();
            return true;
        }

        ShowNotEnoughPoints();
        return false;
    }

    private void ShowNotEnoughPoints()
    {
        if (notEnoughPointsText != null)
        {
            notEnoughPointsText.SetActive(true);
            CancelInvoke(nameof(HideNotEnoughPoints));
            Invoke(nameof(HideNotEnoughPoints), 2f);
        }
    }

    private void HideNotEnoughPoints()
    {
        if (notEnoughPointsText != null)
        {
            notEnoughPointsText.SetActive(false);
        }
    }
}