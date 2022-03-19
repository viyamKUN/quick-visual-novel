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
        public RESULT Check()
        {
            return RESULT.FAIL;
        }
    }
}
