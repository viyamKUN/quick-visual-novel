namespace QVN.Models
{
    using QVN.Story;
    [System.Serializable]
    public class ScenarioLine
    {
        public string Code;
        public int Flag;
        public string Info;
        public string SubInfo;
        public string SubContents;
        public string Contents;

        public ScenarioLine(object code, object flag, object info, object subInfo, object subContents, object contents)
        {
            Code = code.ToString();
            Flag = (int)flag;
            Info = info.ToString();
            SubInfo = subInfo.ToString();
            SubContents = subContents.ToString();
            Contents = contents.ToString();
        }

        public string GetName()
        {
            if (!SubInfo.Equals(string.Empty))
            {
                return SubInfo;
            }
            else
            {
                return Info;
            }
        }

        public FEELING GetFeeling()
        {
            switch (SubContents)
            {
                case "TALK":
                    return FEELING.TALK;
                case "SMILE":
                    return FEELING.SMILE;
                case "ANGRY":
                    return FEELING.ANGRY;
                case "SAD":
                    return FEELING.SAD;
                case "HURT":
                    return FEELING.HURT;
                case "TIRED":
                    return FEELING.TIRED;
                default:
                    return FEELING.IDLE;
            }
        }
    }
}
