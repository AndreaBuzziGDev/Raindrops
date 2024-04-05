using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOrchestrationController : MonoSingleton<ParticleOrchestrationController>
{
    //DATA




    //PREFABS
    [SerializeField] ParticleSystem tearSolutionNormal;
    [SerializeField] ParticleSystem tearSolutionGold;



    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        //REGISTER EVENTS
        TearOperation.TearSolved += HandleSolutionParticles;
    }

    void OnDestroy()
    {
        TearOperation.TearSolved -= HandleSolutionParticles;
    }



    //FUNCTIONALITIES
    private void SpawnParticlesAutoDestroy(ParticleSystem toSpawn, Vector3 position, string name = "Orchestrated Particle", float duration = 5)
    {
        ParticleSystem go = Instantiate(toSpawn);
        go.transform.position = position;

        Destroy(go.gameObject, duration);
    }



    //EVENT HANDLING
    //NB: THIS COULD BE A GREAT USE-CASE FOR OBJECT POOLING
    public void HandleSolutionParticles(object sender, TearEventArgs e)
    {
        ParticleSystem toSpawn;
        switch(e.AffectedTear.TearType)
        {
            case TearOperation.ETearType.GOLD:
                //
                toSpawn = tearSolutionGold;
                break;
            default:
                //
                toSpawn = tearSolutionNormal;
                break;
        }

        //SPAWN PARTICLES
        SpawnParticlesAutoDestroy(toSpawn, e.AffectedTear.gameObject.transform.position, "Tear Solution Particles");
    }
    

}
