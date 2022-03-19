namespace QVN.Models.Story
{
    [System.Serializable]
    public class ScenarioLine
    {
        public string Code;
        public int Flag;
        public string Info;
        public string SubInfo;
        public string Contents;

        public ScenarioLine(object code, object flag, object info, object subInfo, object contents)
        {
            Code = code.ToString();
            Flag = (int)flag;
            Info = info.ToString();
            SubInfo = subInfo.ToString();
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
    }
}
