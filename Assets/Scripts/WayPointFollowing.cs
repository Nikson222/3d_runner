using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollowing : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    private int _currentWaypointIndex = 0;

    [SerializeField] private float _speed = 1f;

    void Update()
    {
        if (Vector3.Distance(transform.position, _wayPoints[_currentWaypointIndex].position) < .1f)
        {
            _currentWaypointIndex++;
            if (_currentWaypointIndex >= _wayPoints.Length)
                _currentWaypointIndex = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWaypointIndex].position, _speed * Time.deltaTime);
    }
}
