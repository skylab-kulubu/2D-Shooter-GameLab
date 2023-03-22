using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        PlayerMove,
        PlayerHurt,

        MaterialPickUp,

        Bat,
        Knife,
        Pistol,
        Rifle,
        Shotgun,

        BulletHit,
        CloseShot,

        FenceUpgrade,
        GunSelect,
        Repair,

        Goblin,
        FlyingEye,
        Skeleton,
        Mushroom

    }
    public static void PlaySound(Sound sound)
    {
        GameObject soundGameOject = new GameObject("Sound");
        AudioSource audioSource = soundGameOject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundClipHolder.SoundAudioClip soundAudioClip in SoundClipHolder.i.soundAudioClipArray)
        {
            if(soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
            
        }
        Debug.LogError($"Sound {sound} not found!");
        return null;
    }
}
