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

	void Awake() {
        LevelNumber = 1;
        PlayerScore = 0;
        CurrentNumberOfPaladins = 0;
        CurrentNumberOfMages = 0;
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
    }
}
