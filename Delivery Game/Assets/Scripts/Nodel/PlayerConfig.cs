using System;
using System.Collections.Generic;

[Serializable]
public class PlayerConfig
{
    public int currentLevel =2 ;

    public Dictionary<int, int> starsLevels = new Dictionary<int, int>();
}
