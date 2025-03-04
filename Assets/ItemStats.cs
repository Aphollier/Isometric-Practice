using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemStats : MonoBehaviour
{
    public PlayerStats stats;
    Dictionary<string, float> itemStats = new Dictionary<string, float>();

    public void addStats(string addedStats)
    {
        string[] divided = addedStats.Split('|');
        foreach(string s in divided)
        {
            string[] split = s.Split(' ');
            itemStats.Add(split[0], float.Parse(split[1]));
        }
        stats.updateStats(itemStats);
    }

    public void removeStats()
    {
        foreach (string key in itemStats.Keys.ToList())
        {
            itemStats[key] = -(itemStats[key]);
        }
        stats.updateStats(itemStats);
        itemStats.Clear();
    }
    
}
