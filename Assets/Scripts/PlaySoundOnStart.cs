using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    void Start()
    {
        AudioHandler.Instance.PlaySound(clip);
    }
}
