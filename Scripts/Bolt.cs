using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {

    public ParticleSystem BoltParticle;
    public SpriteRenderer BoltSprite;

    private Color _currentColor;

    private void Start()
    {
        _currentColor = ColorManager.BallColor;
        _currentColor.a = 1f;
        BoltParticle.startColor = _currentColor;
        BoltSprite.color = _currentColor;
    }
}
