using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

namespace QVN.DefaultSystem
{
    public class CSVReader
    {
        static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
        static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
        static char[] TRIM_CHARS = { '\"' };

        public static List<Dictionary<string, object>> Read(TextAsset asset)
        {
            var list = new List<Dictionary<string, object>>();
            var lines = Regex.Split(asset.text, LINE_SPLIT_RE);

            var header = Regex.Split(lines[0], SPLIT_RE);

            for (int i = 1; i < lines.Length; i++)
            {
                var values = Regex.Split(lines[i], SPLIT_RE);
                if (values.Length < 2 || values[0] == "") continue;

                var entry = new Dictionary<string, object>();

                for (var j = 0; j < header.Length; j++)
                {
                    string value = values[j];
                    value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS);

                    object finalvalue = value;
                    if (int.TryParse(value, out int n))
                        finalvalue = n;
                    else if (float.TryParse(value, out float f))
                        finalvalue = f;

                    entry[header[j]] = finalvalue;
                }
                list.Add(entry);
            }
            return list;
        }
    }
}
