using System;
using System.Collections.Generic;

[Serializable]
public class PlayerConfig
{
    public int currentLevel;

    public static Dictionary<int, int> starsLevels = new Dictionary<int, int>();
}
