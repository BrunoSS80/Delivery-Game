using System;
using System.Collections.Generic;

[Serializable]
public class PlayerConfig
{
    public int currentLevel =1;

    public Dictionary<int, int> starsLevels = new();
}
