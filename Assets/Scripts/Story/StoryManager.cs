using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace QVN.Story
{
    using Models.Story;
    using DefaultUI;

    public class StoryManager : MonoBehaviour
    {
        [SerializeField]
        private SceneLoader _loader;
        [SerializeField]
        private DialogSetter _dialogSetter;
        [SerializeField]
        private StandingSetter _standingSetter;
        [SerializeField]
        private SelectionSetter _selectionSetter;
        [SerializeField]
        private Image _fade;
        private List<ScenarioLine> _scenarioList;
        private int _pin;
        private int _flag;
        private bool _isOnLoading;
        private List<ScenarioLine> _selectionLines;

        private void Awake()
        {
            _selectionSetter.Init();
            int targetScenario = Data.StoryBookmark.GetScenarioID();
            Data.StoryStaticData.ReadData();
            ShowScenario(targetScenario);
        }

        private void ShowScenario(int id)
        {
            _scenarioList = Data.StoryStaticData.GetScenario(id);
            _fade.gameObject.SetActive(false);
            _isOnLoading = false;
            _selectionLines = new List<ScenarioLine>();
            _pin = 0;
            _flag = 0;
            ReadScenario();
        }

        private void ReadScenario()
        {
            var line = _scenarioList[_pin];
            switch (line.Code)
            {
                case "SET":
                    switch (line.Info)
                    {
                        case "Member":
                            _standingSetter.SetStandings(line.Contents);
                            break;
                        case "Name":
                            // TODO: 사용자 이름 입력받기
                            break;
                    }
                    Next();
                    break;
                case "TALK":
                    _dialogSetter.SetDialog(line.GetName(), line.Contents);
                    _standingSetter.SetHighlight(line.Info);
                    break;
                case "SELECT":
                    var nextLine = _scenarioList[_pin + 1];
                    if (!nextLine.Code.Equals("SELECT"))
                    {
                        _selectionLines.Add(line);
                        _selectionSetter.SetSelections(_selectionLines);
                    }
                    else
                    {
                        _selectionLines.Add(line);
                        Next();
                    }
                    break;
            }
        }

        private void EndScenario()
        {
            if (_isOnLoading) return;
            _fade.gameObject.SetActive(true);
            _fade.DOFade(1, 0.5f).From(0).OnComplete(() => _loader.Load(SceneName.Home));
        }

        private void Next()
        {
            _pin++;
            if (_scenarioList.Count <= _pin)
            {
                EndScenario();
            }
            else
            {
                var line = _scenarioList[_pin];
                if (line.Flag == 0 && _flag != 0)
                {
                    _flag = 0;
                }
                if (line.Flag != _flag)
                {
                    Next();
                    return;
                }
                ReadScenario();
            }
        }

        public void GetNextInput()
        {
            var line = _scenarioList[_pin];
            if (line.Code.Equals("SELECT"))
                return;
            if (line.Code.Equals("TALK"))
            {
                if (_dialogSetter.IsAnimationPlaying())
                {
                    _dialogSetter.ForceCompleteAnimation();
                    return;
                }
            }
            Next();
        }

        public void GetSelect(int index)
        {
            if (System.Int32.TryParse(_selectionLines[index].Info, out int flag))
            {
                _flag = flag;
            }
            else
            {
                _flag = 0;
            }
            _selectionLines.Clear();
            Next();
        }

        public void Skip()
        {
            EndScenario();
        }
    }
}
