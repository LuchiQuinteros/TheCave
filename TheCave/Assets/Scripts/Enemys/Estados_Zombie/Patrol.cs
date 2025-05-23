using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol
{
    private Animator _animator;
    private Transform[] _waypoints;

    public Patrol(Animator animator, Transform[] waypoints)
    {
        _animator = animator;
        
        _waypoints = waypoints;
        
    }
    public void PatrolUpdate()
    {
        
        _animator.SetBool("walk", true);
        //if(Vector3.Distance())
        
        //if (_detection == false)
        //{
        //    if (Vector3.Distance(transform.position, target.transform.position) > 5)
        //    {
        //        _animator.SetBool("run", false);

        //        _chronometer += 1 * Time.deltaTime;

        //        if (_chronometer >= 4)
        //        {

        //            _routine = Random.Range(0, 2);
        //            _chronometer = 0;
        //        }

        //        switch (_routine)
        //        {
        //            case 0:
        //                _animator.SetBool("walk", false);
        //                break;
        //            case 1:
        //                _degree = Random.Range(0, 360);

        //                angle = Quaternion.Euler(0, _degree, 0);

        //                _routine++;
        //                break;
        //            case 2:
        //                transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);

        //                transform.Translate(Vector3.forward * 1 * Time.deltaTime);

        //                _animator.SetBool("walk", true);
        //                break;
        //        }
        //    }
        //}
    }

    
    public Transform NextWP(Transform previousWP = null)
    {
        Transform nextwp = _waypoints[Random.Range(0, _waypoints.Length)];

        if(nextwp == previousWP)
        {
            nextwp = _waypoints[Random.Range(0, _waypoints.Length)];
        }

        return nextwp;
    }
}
