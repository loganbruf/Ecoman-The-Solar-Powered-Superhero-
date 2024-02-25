using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        public int health;
        public static LinkedList<Enemy> Enemies;
        public Vector3 spawnPoint;

        public void DestroyOnZeroHealth()
        {
            if (health > 0) return;
            var sound = gameObject.GetComponent<AudioSource>();
            if (sound.isPlaying) return;
            Destroy(gameObject);
        }
    }
}
