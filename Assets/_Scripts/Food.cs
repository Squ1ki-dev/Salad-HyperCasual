using UnityEngine;

public enum FoodType
{
    Harmful,
    Healthy
}

public class Food : MonoBehaviour
{
    public FoodType foodType;

    [SerializeField] private float harmfulFoodPercentage = -10f;
    [SerializeField] private float healthyFoodPercentage = 5f;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player)
        {
            switch (foodType)
            {
                case FoodType.Harmful:
                    //AdjustPlayerPercentage(harmfulFoodPercentage);
                    Debug.Log("Harmful food triggered! Percentage adjusted: " + harmfulFoodPercentage);
                    break;
                case FoodType.Healthy:
                    //AdjustPlayerPercentage(healthyFoodPercentage);
                    Debug.Log("Healthy food triggered! Percentage adjusted: " + healthyFoodPercentage);
                    break;
            }
        }
    }

    private void AdjustPlayerPercentage(float percentage)
    {
        // PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();
        // playerStats.ModifyPercentage(percentage);
    }
}
