using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
  [SerializeField]
  private VillagerState state_;
  [SerializeField]
  private bool running;

  public float speed = 5;
  public float directionChangeInterval = 1;
  public float maxHeadingChange = 30;

  CharacterController controller;
  float heading;
  Vector3 targetRotation;

  void Start()
  {
    state_ = new IdleState();
    running = false;
  }

  void Awake()
  {
    controller = GetComponent<CharacterController>();

    // Set random initial rotation
    heading = Random.Range(0, 360);
    transform.eulerAngles = new Vector3(0, heading, 0);

    StartCoroutine(NewHeading());
  }

  void Update()
  {
    state_.update(this, Time.deltaTime);
    if (running)
    {
      if ((Vector3.zero - transform.position).magnitude <= 5.0f)
      {
        transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
        var forward = transform.TransformDirection(Vector3.forward);
        controller.SimpleMove(forward * speed);
      }
      else
      {
        var forward = (Vector3.zero - transform.position).normalized;
        controller.SimpleMove(forward * speed);
        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);
      }
    }
  }

  public void run()
  {
    Debug.Log("Running");
    running = true;
  }

  public void idle()
  {
    Debug.Log("Idle");
    running = false;
  }

  public void updateState(VillagerState newState)
  {
    state_ = newState;
  }

  /// <summary>
	/// Repeatedly calculates a new direction to move towards.
	/// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
	/// </summary>
	IEnumerator NewHeading()
  {
    while (true)
    {
      NewHeadingRoutine();
      yield return new WaitForSeconds(directionChangeInterval);
    }
  }

  /// <summary>
	/// Calculates a new direction to move towards.
	/// </summary>
	void NewHeadingRoutine()
  {
    var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
    var ceil = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
    heading = Random.Range(floor, ceil);
    targetRotation = new Vector3(0, heading, 0);
  }
}
