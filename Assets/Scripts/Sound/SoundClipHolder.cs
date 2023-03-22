using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClipHolder : MonoBehaviour
{
    public static SoundClipHolder _i;
    public static SoundClipHolder i { 
        get { 
            if (_i == null) _i = Instantiate(Resources.Load<SoundClipHolder>("Game Assets"));
            return _i;
        } 
    }

    public SoundAudioClip[] soundAudioClipArray;
    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

}
