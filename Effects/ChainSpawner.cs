using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipGame.Effects
{
    public class ChainSpawner : MonoBehaviour
    {
        [SerializeField]
        private float offsetRadius;
        private ExplOrchestrator orchestrator;
        private void Awake()
        {
            orchestrator = transform.parent.GetComponent<ExplOrchestrator>();
        }
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine("WaveCooldown");
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void SpawnNextExplosion()
        {
            Vector3 spawnOffset=new Vector3(Random.Range(offsetRadius * -1,offsetRadius), Random.Range(offsetRadius * -1, offsetRadius));
            Instantiate(gameObject,transform.parent.position+spawnOffset, Quaternion.identity,transform.parent);
            orchestrator.waveNum--;
        }

        IEnumerator WaveCooldown()
        {
            if(orchestrator.waveNum<=0)
            {
                
                yield break;
            }
            yield return new WaitForSeconds(orchestrator.waveCooldown);
            SpawnNextExplosion();
        }
    }
}

