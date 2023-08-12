using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipGame.Management {

    [CreateAssetMenu(menuName ="ShipGame/Wave")]
    public class Wave : ScriptableObject
    {
        [SerializeField]
        public GameObject[] enemyPrefab;
        [SerializeField]
        public float[] rotationZ;
        [SerializeField]
        public Vector3[] spawnPos;

        [SerializeField]
        public float timeToNext;
    }


}
