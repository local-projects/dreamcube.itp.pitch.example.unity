using System.Collections.Generic;
using UnityEngine;
using dreamcube.unity.Core.Scripts.AssetLoading;
using dreamcube.unity.Core.Scripts.Configuration.GeneralConfig;

public class DemoSceneManager : BaseSceneManager
{
    //should I do a check to see if the scene exists?
    public List<string> ContentScenesNames;
    private int _currentDemoSceneIndex = 0;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(SceneLoader.LoadSceneAsyncNamed(ContentScenesNames[_currentDemoSceneIndex]));
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightBracket))
        {
            var nextScene = (_currentDemoSceneIndex + 1) % ContentScenesNames.Count;
            LoadSceneWithIndex(nextScene);
            Debug.Log($"Scene Manager loading {nextScene}");
        }
        else if(Input.GetKeyUp(KeyCode.LeftBracket))
        {
            var nextScene = (_currentDemoSceneIndex - 1);
            if (nextScene < 0) nextScene = ContentScenesNames.Count - 1;
            LoadSceneWithIndex(nextScene);
            Debug.Log($"Scene Manager loading {nextScene}");
        }

        else if (Input.GetKeyDown(KeyCode.Z))
        {
            ConfigManager.Instance.generalSettings.Debug = !ConfigManager.Instance.generalSettings.Debug;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

    }




    private void LoadSceneWithIndex(int newDemoSceneIndex)
    {
        if(newDemoSceneIndex >= ContentScenesNames.Count)
        {
            return;
        }

        if(newDemoSceneIndex != _currentDemoSceneIndex)
        {
            _ = SceneLoader.SwitchScenes(ContentScenesNames[_currentDemoSceneIndex], ContentScenesNames[newDemoSceneIndex]);
            _currentDemoSceneIndex = newDemoSceneIndex;
        }
    }
}
