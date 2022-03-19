using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QVN.DataCheck
{
    public enum RESULT
    {
        NONE, SUCCESS, FAIL
    }
    public class DataCheckManager : MonoBehaviour
    {
        private readonly List<string> CODES = new List<string>() {
            "SET", "TALK", "RADIO", "SYSTEM", "SELECT"
        };

        private readonly List<string> FEELINGS = new List<string>() {
            "IDLE","TALK","SMILE","ANGRY","SAD","HURT","TIRED",
        };
        private readonly string READ_FAIL = "데이터 읽기에 실패했습니다.";
        private readonly string NO_CODE_MESSAGE = "존재하지 않는 코드를 입력하였습니다.";
        private readonly string NO_FEELING_MESSAGE = "존재하지 않는 감정을 입력하였습니다.";
        private readonly string INVALID_SELECT_INFO = "선택지가 숫자로 지정되지 않았습니다.";
        private readonly string INVALID_MEMBERS = "멤버 목록에 공백이 포합되었습니다.";

        public (RESULT result, string message, string subMessage) Check()
        {
            try
            {
                Data.StoryStaticData.DeleteData();
                Data.StoryStaticData.ReadData();
                foreach (var id in Data.StoryStaticData.GetScenarioIDs)
                {
                    var scenario = Data.StoryStaticData.GetScenario(id);
                    for (int i = 0; i < scenario.Count; i++)
                    {
                        var line = scenario[i];
                        if (!CODES.Contains(line.Code))
                        {
                            return (RESULT.FAIL, NO_CODE_MESSAGE, GetSubMessage(id, i));
                        }
                        switch (line.Code)
                        {
                            case "TALK":
                                if (!line.SubContents.Equals(string.Empty))
                                {
                                    if (!FEELINGS.Contains(line.SubContents))
                                    {
                                        return (RESULT.FAIL, NO_FEELING_MESSAGE, GetSubMessage(id, i));
                                    }
                                }
                                break;
                            case "SELECT":
                                if (!int.TryParse(line.Info, out int result))
                                {
                                    return (RESULT.FAIL, INVALID_SELECT_INFO, GetSubMessage(id, i));
                                }
                                break;
                            case "SET":
                                if (line.Contents.Contains(" "))
                                {
                                    return (RESULT.FAIL, INVALID_MEMBERS, GetSubMessage(id, i));
                                }
                                break;
                            default: break;
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
                return (RESULT.FAIL, READ_FAIL, string.Empty);
            }
            return (RESULT.SUCCESS, "ok", string.Empty);
        }

        private string GetSubMessage(int id, int index)
        {
            return $"[{id}] Scenario의 {index + 2}번째 라인";
        }
    }
}
