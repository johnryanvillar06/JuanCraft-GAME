using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AssignmentManager;
using static ItemResourceManager;

public class PreSetupManager : MonoBehaviour
{

    public static GameConfig? config;
    public static int level;
  
    private AssignmentManager assignmentManager; 

    [System.Serializable]
    public struct GameConfig
    {
        public bool isLastLevel;
        public Difficulty difficulty;
        public int timeLimit;
        public List<CustomDemand> demands; 
    }

    public enum Difficulty
    {
        EASY = 1, MEDIUM = 2, HARD = 3
    }

    private void Awake()
    {
        if (config == null)
        {
            return;
        }

        GameConfig game = config.Value;

        assignmentManager = GetComponent<AssignmentManager>();
        assignmentManager.customDemands = game.demands;

        GetComponent<SpawnManager>().difficulty = game.difficulty;
        GetComponent<MainManager>().timeLimit = game.timeLimit;
    }

    public static bool isLastLevel()
    {
        return PreSetupManager.config?.isLastLevel ?? false;
    }

}
