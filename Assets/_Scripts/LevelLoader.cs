using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : Singleton<LevelLoader>
{
    public List<GameObject> Levels = new List<GameObject>();

    public int LevelCount
    {
        get { return PlayerPrefs.GetInt("Level", 0); }
        set { PlayerPrefs.SetInt("Level", value); }
    }

    protected override void Awake()
    {
        base.Awake();

        foreach (var item in Resources.LoadAll<GameObject>("Levels"))
            Levels.Add(item);
    }

    private void Start() => LevelCreated();

    private void OnEnable() => EventManager.OnWin += OnLevelComplete;
    private void OnDisable() => EventManager.OnWin -= OnLevelComplete;

    private void OnLevelComplete() => LevelCount++;

    public void LevelCreated()
    {
        ResetLevels();
        if (LevelCount >= Levels.Count)
        {
            int randomIndex = UnityEngine.Random.Range(0, Levels.Count);
            Instantiate(Levels[randomIndex], transform);
        }
        else
            Instantiate(Levels[LevelCount], transform);

        GameStateEvent.Fire_OnChangeGameState(State.Begin);
    }

    private void ResetLevels()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}