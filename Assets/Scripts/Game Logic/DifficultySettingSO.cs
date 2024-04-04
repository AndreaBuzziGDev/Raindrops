using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Difficulty Setting", menuName = "Difficulty Setting")]
public class DifficultySettingSO : ScriptableObject
{
    //DATA
    [SerializeField] float scoreCoefficient = 1.0f;
    [SerializeField] float speedCoefficient = 1.0f;

    //DATA GETTERS
    public float ScoreCoefficient { get { return scoreCoefficient; } }
    public float SpeedCoefficient { get { return speedCoefficient; } }

}
