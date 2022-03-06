namespace QVN.Models.Story
{
    [System.Serializable]
    public class ScenarioLine
    {
        public string Code;
        public int Flag;
        public string Info;
        public string Contents;

        public ScenarioLine(object code, object flag, object info, object contents)
        {
            this.Code = code.ToString();
            this.Flag = (int)flag;
            this.Info = info.ToString();
            this.Contents = contents.ToString();
        }
    }
}
