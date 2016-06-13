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
        MaxNumberOfPaladinsPerLevel = LevelNumber;
        MaxNumberOfMagesPerLevel = LevelNumber;
        if (CurrentNumberOfMages == 0 && CurrentNumberOfPaladins == 0) {
            LevelNumber = LevelNumber + 1;
        }

        //TODO: add spawning
	}

    public void addScoreForKilledPaladin() {
        this.PlayerScore = this.PlayerScore + ScorePerPaladin;
    }

    public void addScoreForKilledMage() {
        this.PlayerScore = this.PlayerScore + ScorePerMage;
    }
}
