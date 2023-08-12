using ShipGame.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipGame.Management
{
    /// <summary>
    /// Enemies must be spawned, and do so in waves.
    /// a wave consists of a number of enemies and their respective spawn positions, as well as the moment in time  in which they appear
    /// the aim is to iterate through waves and spawn enemies in the correct time, and finish it off by then spawning the boss.
    /// </summary>
    /// 
    [CreateAssetMenu(menuName = "ShipGame/Level")]
    public class Level : ScriptableObject
    {
        [SerializeField]
       public List<GameObject> waves=new List<GameObject>();

        public List<float> timeToNext=new List<float>();

    }
}

