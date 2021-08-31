using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    public static EffectManager instance;

    public ParticleSystem particlePrefab;

    private List<ParticleSystem> createdParticles = new List<ParticleSystem>();
    private IEnumerator<ParticleSystem> particleIterator;

	// Use this for initialization
	void Awake () {
        instance = this;
        for (int i = 0; i < 6; i++)
        {
            createdParticles.Add(Instantiate(particlePrefab));
        }

        particleIterator = createdParticles.GetEnumerator();
    }


    public void PlayNoteParticle(Vector3 point)
    {
        if (!particleIterator.MoveNext())
        {
            particleIterator.Reset();
            particleIterator.MoveNext();
        }

        particleIterator.Current.transform.position = point ;
        particleIterator.Current.Play();
    }
}
