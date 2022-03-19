using UnityEngine;
using UnityEditor;

namespace QVN.DataCheck
{
    [CustomEditor(typeof(DataCheckManager))]
    public class DataCheckEditor : Editor
    {
        private GUIStyle _style = new GUIStyle();
        private RESULT _result = RESULT.NONE;
        private string _resultMessage;
        private string _subMessage;
        public override void OnInspectorGUI()
        {
            var manager = target as DataCheckManager;
            base.OnInspectorGUI();
            GUILayout.Space(10);
            GUILayout.Label("시나리오 입력이 끝난 뒤에 이 버튼을 클릭하세요.");
            GUILayout.Space(10);
            if (GUILayout.Button("Check All CSV"))
            {
                var checkerResult = manager.Check();
                _result = checkerResult.result;
                _resultMessage = checkerResult.message;
                _subMessage = checkerResult.subMessage;
                _style.normal.textColor = GetStyleColor();
            }
            GUILayout.Space(10);
            GUILayout.Label($"Result: {_result}", _style);
            if (_result.Equals(RESULT.FAIL))
            {
                GUILayout.Label($"{_resultMessage} \n{_subMessage}");
            }
        }

        private Color GetStyleColor()
        {
            switch (_result)
            {
                case RESULT.NONE:
                    return Color.white;
                case RESULT.FAIL:
                    return Color.red;
                case RESULT.SUCCESS:
                    return Color.cyan;
                default:
                    return Color.gray;
            }
        }
    }
}
