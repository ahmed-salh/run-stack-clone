using System.Collections.Generic;
using UnityEngine;

public class CollectableStackController : MonoBehaviour
{
    private Actor[] _actors;

    private float _actorHeight = 0.8f;

    private void Start()
    {
        _actors = new Actor[transform.childCount];

        for (int i = 0; i < transform.childCount; ++i)
        {
            _actors[i] = transform.GetChild(i).GetComponent<Actor>();
        }

        for (int i = 0; i < _actors.Length; i++)
        {
            _actors[i].transform.localPosition = i * _actorHeight * Vector3.up;
        }

        _actors[0].UpdateAnimation("Stand");

        if (_actors.Length > 1)
        {
            for (int i = 1; i < _actors.Length; i++)
            {
                _actors[i].UpdateAnimation("Sit");
            }
        }
    }
}
