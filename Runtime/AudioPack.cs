using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quartzified.Audio
{
    [CreateAssetMenu(menuName = "Quartzified/Audio/Audio Pack", fileName = "New Audio Pack")]
    public class AudioPack : ScriptableObject
    {
        [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
        public List<AudioClip> AudioClips => audioClips;

        [Space]
        public float volumeOverride = 0f;


        public int MinIndex => 0;
        public int MaxIndex => AudioClips.Count- 1;
        public int ClipCount => AudioClips.Count;

        public float GetAudioClipLength(int clipIndex)
        {
            return AudioClips[clipIndex].length;
        }

        public AudioClip GetRandomClip()
        {
            return AudioClips[Random.Range(0, MaxIndex)];
        }

        /// <summary>
        /// Returns the index of the audio clip.
        /// If the clip is not available in the list the return will be -1.
        /// </summary>
        /// <param name="audioClip"></param>
        /// <returns></returns>
        public int GetIndexFromClip(AudioClip audioClip)
        {
            if (AudioClips.Contains(audioClip))
            {
                return AudioClips.IndexOf(audioClip);
            }

            return -1;
        }

        public void PlayOneShot(AudioSource source, int index = 0, float volume = 1f)
        {
            float tempVolume = source.volume;

            if (volumeOverride != 0)
                source.volume = tempVolume * volumeOverride;
            else
                source.volume = tempVolume * volume;

            source.PlayOneShot(audioClips[index]);
            source.volume = tempVolume;
        }

        public void PlayRandomOneShot(AudioSource source, float volume = 1f)
        {
            AudioClip clip = audioClips[Random.Range(0, ClipCount)];
            float tempVolume = source.volume;

            if (volumeOverride != 0)
                source.volume = tempVolume * volumeOverride;
            else
                source.volume = tempVolume * volume;

            source.PlayOneShot(clip);
            source.volume = tempVolume;
        }

    }

}

