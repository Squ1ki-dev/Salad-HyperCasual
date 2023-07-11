using System;
using System.Collections;
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
    [SerializeField] private ParticleSystem boomParticle;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player)
        {
            switch (foodType)
            {
                case FoodType.Harmful:
                    player.ModifyPercentage(harmfulFoodPercentage);
                    StartCoroutine(DeleteFood());
                    Debug.Log("Harmful food triggered! Percentage adjusted: " + harmfulFoodPercentage);
                    break;
                case FoodType.Healthy:
                    player.ModifyPercentage(healthyFoodPercentage);
                    StartCoroutine(DeleteFood());
                    Debug.Log("Healthy food triggered! Percentage adjusted: " + healthyFoodPercentage);
                    break;
            }
        }
    }

    private IEnumerator DeleteFood()
    {
        boomParticle.Play();
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}

