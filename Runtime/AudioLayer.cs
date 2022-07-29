using System;
using UnityEngine;

namespace Quartzified.Audio
{
    [Serializable]
    public class AudioLayer
    {
        [SerializeField] AudioSource audioSource;
        public AudioSource Source => audioSource;
        public void SetSource(AudioSource _source) => audioSource = _source;

        [SerializeField] SourceProfile sourceProfile;
        public SourceProfile Profile => sourceProfile;
        public void SetProfile(SourceProfile _profile) => sourceProfile = _profile;

        [SerializeField] DateTime delayTime;
        public DateTime DelayTime => delayTime;
        public void SetDelay(DateTime _delay) => delayTime = _delay;

        #region Play Effect

        public void PlayEffect(AudioClip clip, bool rndPitch = false)
        {
            if (DateTime.Now < delayTime)
                return;

            // Save Pitch incase we change
            float tempPitch = Source.pitch;

            // Set Pitch if random
            if (rndPitch)
                Source.pitch = UnityEngine.Random.Range(Profile.LowPitch, Profile.HighPitch);

            // Play Random Effect
            Source.PlayOneShot(clip);
            SetDelay(DateTime.Now.AddSeconds(Profile.Delay));

            // Reset Pitch
            Source.pitch = tempPitch;
        }

        public void PlayEffect(AudioPack pack, bool rndPitch = false)
        {
            if (DateTime.Now < delayTime)
                return;

            // Save Pitch incase we change
            float tempPitch = Source.pitch;

            // Set Pitch if random
            if (rndPitch)
                Source.pitch = UnityEngine.Random.Range(Profile.LowPitch, Profile.HighPitch);

            // Play Effect
            Source.PlayOneShot(pack.AudioClips[0]);
            SetDelay(DateTime.Now.AddSeconds(Profile.Delay));

            // Reset Pitch
            Source.pitch = tempPitch;
        }

        public void PlayRandomEffect(AudioClip[] clips, bool rndPitch = false)
        {
            if (DateTime.Now < delayTime)
                return;

            // Save Pitch incase we change
            float tempPitch = Source.pitch;

            // Set Pitch if random
            if (rndPitch)
                Source.pitch = UnityEngine.Random.Range(Profile.LowPitch, Profile.HighPitch);

            // Select Random Effect
            int rndIndex = UnityEngine.Random.Range(0, clips.Length);

            // Play Random Effect
            Source.PlayOneShot(clips[rndIndex]);
            SetDelay(DateTime.Now.AddSeconds(Profile.Delay));

            // Reset Pitch
            Source.pitch = tempPitch;
        }

        public void PlayRandomEffect(AudioPack pack, bool rndPitch = false)
        {
            if (DateTime.Now < delayTime)
                return;

            // Save Pitch incase we change
            float tempPitch = Source.pitch;

            // Set Pitch if random
            if (rndPitch)
                Source.pitch = UnityEngine.Random.Range(Profile.LowPitch, Profile.HighPitch);

            // Play Random Effect
            Source.PlayOneShot(pack.GetRandomClip());
            SetDelay(DateTime.Now.AddSeconds(Profile.Delay));

            // Reset Pitch
            Source.pitch = tempPitch;
        }

        #endregion

        #region Play Audio

        public void PlayAudio(AudioClip clip)
        {
            Source.clip = clip;
            Source.Play();
        }

        public void PlayAudio(AudioPack pack)
        {
            Source.clip = pack.AudioClips[0];
            Source.Play();
        }

        public void PlayRandomAudio(AudioClip[] clips)
        {
            int rndIndex = UnityEngine.Random.Range(0, clips.Length);

            Source.clip = clips[rndIndex];
            Source.Play();
        }

        public void PlayRandomAudio(AudioPack pack)
        {
            Source.clip = pack.GetRandomClip();
            Source.Play();
        }

        #endregion
    }
}