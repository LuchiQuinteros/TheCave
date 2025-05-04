using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : Detection
{
    private void Update()
    {
        if (_detection == true)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !_attacking)
            {
                var lookpos = target.transform.position - transform.position;

                lookpos.y = 0;

                var rotation = Quaternion.LookRotation(lookpos);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

                _animator.SetBool("run", false);

                _animator.SetBool("run", true);

                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                _animator.SetBool("attack", false);
            }
        }
    }
}
