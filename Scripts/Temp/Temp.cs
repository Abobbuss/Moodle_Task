using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    private Transform[] _waypoints;
    private Transform _allPlacesPoint;
    private int _currentWaypointIndex;

    private void Start()
    {
        InitializeWaypoints();
    }

    private void InitializeWaypoints()
    {
        _waypoints = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
        {
            _waypoints[i] = _allPlacesPoint.GetChild(i);
        }
    }

    private void Update()
    {
        Transform currentWaypoint = _waypoints[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, _movementSpeed * Time.deltaTime);

        if (transform.position == currentWaypoint.position) 
            TakeNextPlace();
    }

    private void TakeNextPlace()
    {
        _currentWaypointIndex++;

        if (_currentWaypointIndex == _waypoints.Length)
            _currentWaypointIndex = 0;

        Vector3 nextWaypointPosition = _waypoints[_currentWaypointIndex].transform.position;
        transform.forward = nextWaypointPosition - transform.position;
    }
}