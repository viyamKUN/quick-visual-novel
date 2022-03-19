using UnityEngine;

namespace QVN.Home
{
    public class HomeManager : MonoBehaviour
    {
        [SerializeField]
        private ScenarioList _scenarioList;
        [SerializeField]
        private DefaultUI.SceneLoader _sceneLoader;

        private void Start()
        {
            Data.LocalData.ReadLocalData();
            Data.StoryStaticData.ReadData();
            _scenarioList.Init();
        }

        public void ChangeLanguage(int value)
        {
            Data.LocalData.ChangeLanguage((Data.LANGUAGE)value);
            Data.StoryStaticData.DeleteData();
            Data.StoryStaticData.ReadData();
            _scenarioList.Init();
        }

        public void MoveToStoryScene(int scenarioID)
        {
            Data.StoryBookmark.SetScenarioID(scenarioID);
            _sceneLoader.Load(DefaultUI.SceneName.Story);
        }
    }
}
