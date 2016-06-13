using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour {
    public int LevelNumber;
    public int PlayerScore;

    public int ScorePerPaladin;
    public int ScorePerMage;

    private int MaxNumberOfPaladinsPerLevel;
    private int MaxNumberOfWizzardsPerLevel;
    public int CurrentNumberOfPaladins;
    public int CurrentNumberOfMages;
    
    private bool isLevelStart;
    private bool shouldStartNewLevel;

    public float paladinSpawnTime = 3.0f;
    public float wizzardSpawnTime = 4.5f;
    public Transform[] spawnPoints;

    public GameObject paladinPrefab;
    public GameObject wizzardPrefab;

    private GUIStyle guiStyle = new GUIStyle();

    public int numberOfKilledPaladinsPerLevel;
    public int numberOfKilledWizzardsPerLevel;

    void Awake() {
        LevelNumber = 1;
        PlayerScore = 0;
        CurrentNumberOfPaladins = 0;
        CurrentNumberOfMages = 0;
        StartCoroutine(RemoveLabel());
        InvokeRepeating("SpawnPaladin", paladinSpawnTime, paladinSpawnTime);
        InvokeRepeating("SpawnWizzard", wizzardSpawnTime, wizzardSpawnTime);
        shouldStartNewLevel = false;
        numberOfKilledPaladinsPerLevel = 0;
        numberOfKilledWizzardsPerLevel = 0;
    }

    void OnGUI() {
        if (isLevelStart) {
            guiStyle.fontSize = 40;
            guiStyle.normal.textColor = Color.red;
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, Screen.width, Screen.height), "Level " + LevelNumber, guiStyle);
        }
    }

	void Update() {
        CurrentNumberOfPaladins = GameObject.FindGameObjectsWithTag("Paladin").Length;
        CurrentNumberOfMages = GameObject.FindGameObjectsWithTag("Wizzard").Length;;
        if (numberOfKilledPaladinsPerLevel == MaxNumberOfPaladinsPerLevel && numberOfKilledWizzardsPerLevel == MaxNumberOfWizzardsPerLevel) {
            LevelNumber = LevelNumber + 1;
            startLevel();
        }
    }

    public void addScoreForKilledPaladin() {
        this.PlayerScore = this.PlayerScore + ScorePerPaladin;
        CurrentNumberOfPaladins = CurrentNumberOfPaladins - 1;
        numberOfKilledPaladinsPerLevel = numberOfKilledPaladinsPerLevel + 1;
    }

    public void addScoreForKilledMage() {
        this.PlayerScore = this.PlayerScore + ScorePerMage;
        CurrentNumberOfMages = CurrentNumberOfMages - 1;
        numberOfKilledWizzardsPerLevel = numberOfKilledWizzardsPerLevel + 1;
    }

    private void startLevel() {
        MaxNumberOfPaladinsPerLevel = LevelNumber;
        MaxNumberOfWizzardsPerLevel = LevelNumber;
        CurrentNumberOfPaladins = 0;
        CurrentNumberOfMages = 0;
        numberOfKilledPaladinsPerLevel = 0;
        numberOfKilledWizzardsPerLevel = 0;
    }

    IEnumerator RemoveLabel() {
        isLevelStart = true;
        yield return new WaitForSeconds(5);
        isLevelStart = false;
    }

    private void SpawnPaladin() {
        if (CurrentNumberOfPaladins < MaxNumberOfPaladinsPerLevel) {
            GameObject newPaladin = (GameObject)Instantiate(paladinPrefab, this.transform.position, Quaternion.identity);
            CurrentNumberOfPaladins = CurrentNumberOfPaladins + 1;
        }
    }

    private void SpawnWizzard() {
        if (CurrentNumberOfMages < MaxNumberOfWizzardsPerLevel) {
            GameObject newWizzard = (GameObject)Instantiate(wizzardPrefab, this.transform.position, Quaternion.identity);
            CurrentNumberOfMages = CurrentNumberOfMages + 1;
        }
    }
}

