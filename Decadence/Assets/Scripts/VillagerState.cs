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
    Debug.Log(time);
    if (time <= 0)
    {
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
    Debug.Log(time);
    if (time <= 0)
    {
      villager.updateState(new IdleState());
      villager.idle();
    }
  }
}