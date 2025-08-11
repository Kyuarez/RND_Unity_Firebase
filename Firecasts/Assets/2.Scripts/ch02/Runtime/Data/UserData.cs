using System;
using UnityEngine;

namespace TK.Ch02
{
    [Serializable]
    public class UserData 
    {
        public string NickName;
        public int Score;

        public UserData(string nickname, int score = 0)
        {
            NickName = nickname;
            Score = score;
        }
    }
}
