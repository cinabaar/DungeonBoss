using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour {
    private int LevelNumber;
    private int PlayerScore;

    public int ScorePerPaladin;
    public int ScorePerMage;

    private int MaxNumberOfPaladinsPerLevel;
    private int MaxNumberOfMagesPerLevel;
    private int CurrentNumberOfPaladins;
    private int CurrentNumberOfMages;
    
    private int MaxEnemiesAtTheSameTime;

    private bool isLevelStart;

    void Awake() {
        LevelNumber = 1;
        PlayerScore = 0;
        CurrentNumberOfPaladins = 0;
        CurrentNumberOfMages = 0;
        StartCoroutine(RemoveLabel());
    }

    void OnGUI() {
        if (isLevelStart) {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width, Screen.height), "Level " + LevelNumber);
        }
    }

	void Update() {
        CurrentNumberOfPaladins = GameObject.FindGameObjectsWithTag("Paladin").Length;
        CurrentNumberOfMages = GameObject.FindGameObjectsWithTag("Wizzard").Length;;
        if (CurrentNumberOfMages == 0 && CurrentNumberOfPaladins == 0) {
            LevelNumber = LevelNumber + 1;
            startLevel();
        }
        //TODO: add spawning handling
    }

    public void addScoreForKilledPaladin() {
        this.PlayerScore = this.PlayerScore + ScorePerPaladin;
        CurrentNumberOfPaladins = CurrentNumberOfPaladins - 1;
    }

    public void addScoreForKilledMage() {
        this.PlayerScore = this.PlayerScore + ScorePerMage;
        CurrentNumberOfMages = CurrentNumberOfMages - 1;
    }

    private void startLevel() {
        MaxNumberOfPaladinsPerLevel = LevelNumber;
        MaxNumberOfMagesPerLevel = LevelNumber;
        StartCoroutine(RemoveLabel());
    }

    IEnumerator RemoveLabel() {
        isLevelStart = true;
        yield return new WaitForSeconds(5);
        isLevelStart = false;
    }
}

