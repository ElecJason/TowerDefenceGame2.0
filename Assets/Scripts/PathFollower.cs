using Opdrachten;
using UnityEngine;
using UnityEngine.Events;

public class PathFollower : Path
{
    [SerializeField] private float _speed = 30;
    [SerializeField] private float _arrivalthreshold = 0.1f;
    [SerializeField] private UnityEvent playerDmg;
    [SerializeField] private UnityEvent dmgparticle;

    private void Start()
    {
        GetNextWaypoint();
        //transform.position = startPoint.transform.position;
    }

    private void Update()
    {
        GetNextWaypoint();
        Vector3 heightOffsetPosition = new Vector3(nextTarget.transform.position.x, transform.position.y, nextTarget.transform.position.z);
        float distance = Vector3.Distance(transform.position, heightOffsetPosition);

        if (distance <= _arrivalthreshold)
        {
            if (waypointIndex == waypointsArray.Length - 1)
            {
                //Debug.Log("Ik ben bij het eindpunt"); dit stukje code voor als je het eindpunt bereikt
                Destroy(this.gameObject);
                playerDmg.Invoke();
                dmgparticle.Invoke();
            }
            else
            {
                waypointIndex += 1;
            }
        }
        else
        {
            transform.LookAt(heightOffsetPosition);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
    }
}