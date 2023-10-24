using UnityEngine;
using UnityEngine.UI;

public class SoulIcon : MonoBehaviour
{
    public Image iconImage;
    public int maxEnemies = 10; // Change this to the number of enemies needed to fill the icon
    [SerializeField]
    private float enemyKillCount = 0;

    private void Start()
    {
        // Set the initial state to empty
        UpdateSoulIcon();
    }

    public void EnemyKilled()
    {
        if (enemyKillCount < maxEnemies)
        {
            enemyKillCount++;
            UpdateSoulIcon();
        }
    }

    private void UpdateSoulIcon()
    {
        float fillAmount = (float)enemyKillCount / maxEnemies;
        iconImage.fillAmount = fillAmount;

        // You can also change the image sprite when it's full or use animations here
    }
}
