using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Difficulty Setting", menuName = "Difficulty Setting")]
public class DifficultySettingSO : ScriptableObject
{
    //DATA
    [SerializeField] UtilsPrefs.GameSettings.DIFFICULTY difficultyValue = UtilsPrefs.GameSettings.DIFFICULTY.EASY;

    //TODO: FORCE THESE TO BE A POSITIVE VALUE
    [SerializeField] float speedCoefficient = 1.0f;
    [SerializeField] float scoreCoefficient = 1.0f;

    //DATA GETTERS
    public UtilsPrefs.GameSettings.DIFFICULTY DifficultyValue { get { return difficultyValue; } }
    public float SpeedCoefficient { get { return speedCoefficient; } }
    public float ScoreCoefficient { get { return scoreCoefficient; } }

}
