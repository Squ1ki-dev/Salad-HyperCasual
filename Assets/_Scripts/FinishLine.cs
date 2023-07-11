using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            EventManager.OnFinishAreas();
            GameStateEvent.Fire_OnChangeGameState(State.GameEnd);
        }
    }

    // private void ScoreIncrease()
    // {
    //     PlayerPrefs.SetInt(Tags.Score, PlayerPrefs.GetInt(Tags.Score) + StackController.scoreAmount);
    //     ButtonController.Instance.totalScore.text = PlayerPrefs.GetInt(Tags.Score).ToString();
    //     StackController.scoreAmount = 0;
    // }
}