using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stage Data", menuName = "Stage Data")]
public class StageDataSO : ScriptableObject
{
    #region DATA

    //ASSOCIATED SCENE
    [SerializeField] private string associatedSceneName;
    public string AssociatedSceneName { get { return associatedSceneName; } }
    
    //ENUM IDENTIFIER
    [SerializeField] private SceneNavigationController.eSceneName stageID;
    public SceneNavigationController.eSceneName StageID { get { return stageID; } }
    
    #endregion
}
