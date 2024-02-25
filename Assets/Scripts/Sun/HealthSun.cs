using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Sun
{
    public AudioSource sound;
    public override void ApplyEffect(PlayerActions player)
    {
        player.RestoreHealth(3);
        sound.Play();
    }
}
