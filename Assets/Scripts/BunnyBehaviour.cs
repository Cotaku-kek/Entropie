using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyBehaviour : MonoBehaviour
{
    [SerializeField] AudioSource AudioScratch;
    [SerializeField] AudioSource AudioBreath;

    int ChanceScratches = 42;
    int ChanceBreath = 58;

    public void GiveHint()
    {
        int chance = Random.Range(1, 100);
        if (chance <= ChanceScratches)
        {
            DoScratchesHint();
        }
        else { DoBreathHint(); }
    }

    private void DoBreathHint()
    {
        AudioScratch.Play();
    }

    private void DoScratchesHint()
    {
        AudioBreath.Play();
    }
}
