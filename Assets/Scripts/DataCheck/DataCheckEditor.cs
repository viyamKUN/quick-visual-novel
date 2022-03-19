using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace QVN.DataCheck
{
    [CustomEditor(typeof(DataCheckManager))]
    public class DataCheckEditor : Editor
    {
        private GUIStyle _style = new GUIStyle();
        private RESULT _result = RESULT.NONE;
        public override void OnInspectorGUI()
        {
            var manager = target as DataCheckManager;
            base.OnInspectorGUI();
            GUILayout.Space(10);
            GUILayout.Label("시나리오 입력이 끝난 뒤에 이 버튼을 클릭하세요.");
            GUILayout.Space(10);
            if (GUILayout.Button("Check All CSV"))
            {
                _result = manager.Check();
                _style.normal.textColor = GetStyleColor();
            }
            GUILayout.Space(10);
            GUILayout.Label($"Result: {_result}", _style);
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
