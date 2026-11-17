using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace XIV.Packages.SaveSystems
{
    public static class SaveManager
    {
        public static bool isSaving { get; private set; }
        public static bool isLoading { get; private set; }
        
        static SaveHelper _saveHelper;
        static SaveHelper saveHelper
        {
            get
            {
                if (_saveHelper == false)
                    _saveHelper = new GameObject("SaveHelper").AddComponent<SaveHelper>();
                return _saveHelper;
            }
        }

        public static void SaveAllOpenScenesImmediate()
        {
            int count = SceneManager.sceneCount;
            for (int i = 0; i < count; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                SaveSystem.Save(scene.name);
            }
        }

        public static void LoadAllOpenScenesImmediate()
        {
            int count = SceneManager.sceneCount;
            for (int i = 0; i < count; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                SaveSystem.Load(scene.name);
            }
        }

        public static void SaveSceneDataAsync(int sceneBuildIndex, Action onCompleted = null)
        {
            saveHelper.SaveAsync(sceneBuildIndex, onCompleted);
        }

        public static void LoadSceneDataAsync(int sceneBuildIndex, Action onCompleted = null)
        {
            saveHelper.LoadAsync(sceneBuildIndex, onCompleted);
        }

        class SaveHelper : MonoBehaviour
        {
            internal void SaveAsync(int sceneBuildIndex, Action onCompleted = null)
            {
                if (isSaving) return;
                var sceneName = SceneManager.GetSceneByBuildIndex(sceneBuildIndex).name;
                StartCoroutine(StartSave(sceneName, onCompleted));
            }

            internal void LoadAsync(int sceneBuildIndex, Action onCompleted = null)
            {
                if (isLoading) return;
                var sceneName = SceneManager.GetSceneByBuildIndex(sceneBuildIndex).name;
                StartCoroutine(StartLoad(sceneName, onCompleted));
            }

            internal static IEnumerator StartSave(string sceneName, Action onCompleted = null)
            {
                isSaving = true;
                yield return SaveSystem.SaveAsync(sceneName);
                onCompleted?.Invoke();
                isSaving = false;
            }

            internal static IEnumerator StartLoad(string sceneName, Action onCompleted = null)
            {
                isLoading = true;
                yield return SaveSystem.LoadAsync(sceneName);
                onCompleted?.Invoke();
                isLoading = false;
            }
        }
    }
}