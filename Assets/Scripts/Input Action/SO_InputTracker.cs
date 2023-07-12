using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Manager", menuName = "Managers/Input Tracker")]
public class SO_InputTracker : ScriptableObject
{
    public float userInput;

    // what happens when the players press shoot
    public Action OnShoot;
}
