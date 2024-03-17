using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigationController : MonoBehaviour
{
    //ENUMS
    #region ENUMS
    public enum eSceneName
    {
        TitleScreen,
        MainMenu,
        Credits,
        RaindropsGame
    }
    #endregion
    
    //DATA
    #region DATA

    ///SERIALIZED LIST OF ALL STAGES
    [SerializeField] private List<StageDataSO> StageData = new();
    
    
    ///DICTIONARY FOR RUNTIME ACCESS
    private Dictionary<eSceneName, StageDataSO> StageSceneDictionary = new();
    
    
    /// HAS LOADED
    private bool hasLoaded = false;
    public bool HasLoaded { get { return hasLoaded; } }

    #endregion
    
    
    
    
    

    
    //LIFECYCLE FUNCTIONS
    #region LIFECYCLE FUNCTIONS
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (StageDataSO s in StageData)
        {
            StageSceneDictionary.Add(s.StageID, s);

        }
        hasLoaded = true;
    }
    
    #endregion
    
    
    
    #region FUNCTIONALITIES
    public void LoadScene(eSceneName targetScene)
    {
        string intendedScene = StageSceneDictionary[targetScene].AssociatedSceneName;
        
        if (!string.IsNullOrEmpty(intendedScene)) 
            SceneManager.LoadScene(intendedScene);
        else 
            Debug.Log("Invalid Target Scene: " + targetScene);
    }
    
    #endregion

}
