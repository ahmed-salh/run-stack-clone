using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    private List<Actor> actors;

    private float actorHeight = 0.8f;


    private void OnEnable()
    {
        CollisionEventsHandler.onCollected += AddToStack;
        CollisionEventsHandler.onHitObstacle += RemoveFromStack;
    }

    private void OnDisable()
    {
        CollisionEventsHandler.onCollected -= AddToStack;
        CollisionEventsHandler.onHitObstacle -= RemoveFromStack;
    }

    private void AddToStack(Transform other) {

        Actor[] newActors = other.transform.GetComponentsInChildren<Actor>();

        for (int i = 0; i < newActors.Length; i++)
        {
            newActors[i].transform.SetParent(transform, false);

            newActors[i].transform.SetSiblingIndex(i);
        }

        UpdateStackList();

        UpdateActorsPosition();

        UpdateActorsAnimation();
    }

    private void RemoveFromStack(Transform other) 
    {
        int removeCount = other.transform.childCount;

        if (transform.childCount <= removeCount)
        {
            GameplayEventsHandeler.GameOver?.Invoke();
            return;
        }

        for (int i = 0; i < removeCount; i++) 
        {
            actors[i].transform.SetParent(null);

            actors[i].Die(i);
        }

        UpdateStackList();

        UpdateActorsPosition();

        UpdateActorsAnimation();
    }


    private void UpdateStackList() 
    {
        actors = new List<Actor>();

        for (int i = 0; i < transform.childCount; ++i)
        {
            actors.Add(transform.GetChild(i).GetComponent<Actor>());
        }
    }

    private void UpdateActorsPosition() 
    {
        for (int i = 0; i < actors.Count; i++)
        {
            actors[i].transform.localPosition = i * actorHeight * Vector3.up;
        }
    }
    
    private void UpdateActorsAnimation()
    {
        actors[0].UpdateAnimation("Run"); // First actor

        if (actors.Count > 1)
        {
            for (int i = 1; i < actors.Count - 1; i++)
            {
                actors[i].UpdateAnimation("Sit"); // Other actors
            }

            actors[actors.Count - 1].UpdateAnimation("Clap"); // Last actor
        }
    }
}

