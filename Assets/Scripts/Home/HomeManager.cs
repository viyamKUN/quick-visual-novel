using UnityEngine;

namespace QVN.Home
{
    public class HomeManager : MonoBehaviour
    {
        [SerializeField]
        private DefaultUI.SceneLoader _sceneLoader;
        [Header("UI")]
        [SerializeField]
        private ScenarioList _scenarioList;
        [SerializeField]
        private DropdownSetter _dropdownSetter;

        private void Start()
        {
            Data.LocalData.ReadLocalData();
            RefreshStoryDataAndUI();

            var lanIndex = Data.LocalData.GetLanguage;
            _dropdownSetter.SetIndex((int)lanIndex);
        }

        public void ChangeLanguage(int value)
        {
            Data.LocalData.ChangeLanguage((Data.LANGUAGE)value);
            Data.StoryStaticData.DeleteData();
            RefreshStoryDataAndUI();
        }

        public void MoveToStoryScene(int scenarioID)
        {
            Data.StoryBookmark.SetScenarioID(scenarioID);
            _sceneLoader.Load(DefaultUI.SceneName.Story);
        }

        private void RefreshStoryDataAndUI()
        {
            Data.StoryStaticData.ReadData();
            _scenarioList.Init();
        }
    }
}
