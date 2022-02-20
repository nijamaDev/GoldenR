using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
  // camera will follow this object
  public Transform Target;
  //camera transform
  public Transform camTransform;
  // offset between camera and target
  private Vector3 Offset;
  // change this value to get desired smoothness
  public float SmoothTime;
  public float damping;
  // This value will change at the runtime depending on target movement. Initialize with zero vector.
  private Vector3 velocity = Vector3.zero;

  private void Start()
  {
    Offset = camTransform.position - Target.position;
  }

  private void LateUpdate()
  {
    // update position
    Vector3 targetPosition = Target.position + Offset;
    camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

    // update rotation
    //transform.LookAt(Target);
    var rotation = Quaternion.LookRotation(Target.position - transform.position);
    // rotation.x = 0; This is for limiting the rotation to the y axis. I needed this for my project so just
    // rotation.z = 0;                 delete or add the lines you need to have it behave the way you want.
    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

  }
}