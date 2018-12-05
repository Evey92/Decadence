using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerState
{
  public virtual void handleInput(Villager villager)
  {

  }

  public virtual void update(Villager villager, float deltaTime)
  {

  }
}

public class IdleState : VillagerState
{
  private float time;

  public IdleState()
  {
    time = 2.0f;
  }

  public override void handleInput(Villager villager)
  {

  }

  public override void update(Villager villager, float deltaTime)
  {
    time -= deltaTime;
    //Debug.Log(time);
    if (time <= 0) {
      villager.updateState(new WanderState());
      villager.run();
    }
  }
}

public class WanderState : VillagerState
{
  private float time;

  public WanderState()
  {
    time = 5.0f;
  }

  public override void handleInput(Villager villager)
  {

  }

  public override void update(Villager villager, float deltaTime)
  {
    time -= deltaTime;
    //Debug.Log(time);
    if (time <= 0) {
      villager.updateState(new IdleState());
      villager.idle();
    }
  }
}

public class RunningState : VillagerState
{
  GameObject enemy;

  public RunningState(GameObject go)
  {
    enemy = go;
  }

  public override void handleInput(Villager villager)
  {

  }

  public override void update(Villager villager, float deltaTime)
  {
    Vector2 steering = flee(villager);
    Vector2 vel = steering * deltaTime;
    Vector2 pos = new Vector2(villager.transform.position.x, villager.transform.position.z);
    Vector2 newPos = pos + vel * deltaTime;
    Vector3 finalPos = new Vector3(newPos.x, villager.transform.position.y, newPos.y);
    villager.transform.position = finalPos;
    if ((villager.transform.position - finalPos).magnitude >= 10.0f) {
      villager.updateState(new WanderState());
      villager.run();
    }
  }

  private Vector2 flee(Villager villager)
  {
    Vector2 fleeForce = new Vector2(villager.transform.position.x, villager.transform.position.z) - new Vector2(enemy.transform.position.x, enemy.transform.position.z);
    if(fleeForce.magnitude<=10.0f) { fleeForce.Normalize(); }
    else { fleeForce *= 0; }
    return fleeForce * 500.0f;
  }
}