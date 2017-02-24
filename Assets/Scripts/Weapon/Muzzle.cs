using UnityEngine;
using System.Collections;
using System;

namespace UntitledLOL
{
    public class Muzzle : MonoBehaviour
    {

        ParticleSystem muzzleFlash;
        AudioSource audioSrc;

        void OnEnable()
        {
            muzzleFlash = transform.FindChild("MuzzleFlash").GetComponent<ParticleSystem>();
            audioSrc = GetComponent<AudioSource>();
        }

        public void ShootEffects()
        {
            if(muzzleFlash)
            {
                //muzzleFlash.randomSeed = (uint) UnityEngine.Random.Range(0, int.MaxValue);
                muzzleFlash.Play();
            }

            if(audioSrc)
            {
                audioSrc.Play();
            }
        }

    }

}