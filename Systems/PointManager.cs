using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipGame.Management
{
    public class PointManager : MonoBehaviour
    {
        private int points=0;
        static PointManager instance;
        private void Awake()
        {
            //set self as instance for other stuff to call on you
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public static void AwardPoints(int pointsToAdd)
        {
            instance.points+=pointsToAdd;
            UpdatePoints();
        }

        public static void UpdatePoints()
        {
            UIManager.UpdateScore(instance.points);
        }

    }
}

