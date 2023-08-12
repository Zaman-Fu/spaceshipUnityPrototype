using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace ShipGame.Management
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        Level level;
        int waveIndex=0;
        float currentCooldown=5;
        [SerializeField]
        GameObject boss;
        // Start is called before the first frame update
        void Start()
        {
            
            StartCoroutine("WaveCooldown");
        }

        // Update is called once per frame
        
        void Update()
        {

        }


        private void SpawnWave()
        {
            if (waveIndex >=level.waves.Count)
            {
                SpawnBoss();
                return;
            }

          GameObject currentWave =  level.waves.ElementAt(waveIndex);
            Instantiate(currentWave);
            
            currentCooldown=level.timeToNext.ElementAt(waveIndex);
            StartCoroutine("WaveCooldown");
            waveIndex++;
        }

        private void SpawnBoss()
        {
            Debug.Log("Spawning Boss!");
            //No boss here, so run countdown and end game for now.
            StartCoroutine("CheckForVisibleEnemies");
           
        }


        IEnumerator WaveCooldown()
        {
            Debug.Log("Time to next wave: " + currentCooldown);
            yield return new WaitForSeconds(currentCooldown);
            SpawnWave();
        }

        IEnumerator LevelClearCountDown()
        {
            yield return new WaitForSeconds(1);
            UIManager.GameOver();
        }

        IEnumerator CheckForVisibleEnemies()
        {
           var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            while(enemies.Length!=0)
            {
                yield return new WaitForSeconds(1);
                Debug.Log("There are still enemies");
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
            }
            Instantiate(boss, new Vector3(0, 25, 0), Quaternion.identity);
            //StartCoroutine("LevelClearCountDown");

            yield break;

        }
    }
}

