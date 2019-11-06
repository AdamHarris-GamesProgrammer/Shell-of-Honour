using System.ComponentModel;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int score = 0;

    public void ScoreUp(int amount)
    {
        score += amount;
    }
}
