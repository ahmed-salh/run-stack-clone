using UnityEngine;

public class ObstacleStackController : MonoBehaviour
{
    private Transform[] _obstacles;

    public float spacing = 0.09f;

    public float height = 0.8f;

    private void Start()
    {
        _obstacles = new Transform[transform.childCount];

        for (int i = 0; i < _obstacles.Length; ++i)
        {
            _obstacles[i] = transform.GetChild(i);

            _obstacles[i].transform.localPosition = i * (height + spacing) * Vector3.up;
        }
    }
}
