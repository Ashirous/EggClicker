using TMPro;
using UnityEngine;

public class PointsGenerator : MonoBehaviour
{
    public PointsManager pointsManager;
    public TMP_Text upgradePointsPerSecondCostText;
    public int pointsPerSecond = 1;
    public int upgradePointsPerSecondCost = 1;

    void Start()
    {
        upgradePointsPerSecondCostText.text = upgradePointsPerSecondCost.ToString();
    }

    public void UpgradePointsPerSecond()
    {
        if (pointsManager.TrySpendPoints(upgradePointsPerSecondCost))
        {
            pointsManager.AddPointsPerSecond(pointsPerSecond);
            upgradePointsPerSecondCost *= 2;
            upgradePointsPerSecondCostText.text = upgradePointsPerSecondCost.ToString();
        }
    }
}