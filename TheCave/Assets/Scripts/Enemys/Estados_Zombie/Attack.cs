using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Attack : Detection_Attack
{
    private void Update()
    {
        //if (_detection == true && _detectionAttack == true)
        //{
        //    if (Vector3.Distance(transform.position, target.transform.position) > 1 && !_attacking)
        //    {
        //        var lookpos = target.transform.position - transform.position;

        //        lookpos.y = 0;

        //        var rotation = Quaternion.LookRotation(lookpos);

        //        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

        //        _animator.SetBool("run", false);

        //        _animator.SetBool("run", true);

        //        transform.Translate(Vector3.forward * 2 * Time.deltaTime);

        //        _animator.SetBool("attack", false);
        //    }
        //    else
        //    {
        //        _animator.SetBool("run", false);
        //        _animator.SetBool("walk", false);

        //        _animator.SetBool("attack", true);
        //        _attacking = true;
        //    }
        //}
    }
}
