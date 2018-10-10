using System.Collections;                                                                     
using System.Collections.Generic;                                                             
using UnityEngine;

public class BreakObject : MonoBehaviour
{
  // Breakable object m_hp                                                                      
  public GameObject m_brokenObject;
  private float m_hp;

  // Use this for initialization                                                              
  void Start()
  {
    // Sets m_hp to 1, that means any kind of damage will break the object                      
    m_hp = 1;
  }

  // Update is called once per frame                                                          
  void Update()
  {
    // Check if m_hp reaches 0                                                                  
    if (m_hp <= 0) {
      // If it does, the broken object is instatiated in its place and this one gets destroyed
      Instantiate(m_brokenObject, this.transform.position, this.transform.rotation);
      Destroy(gameObject);
    }
  }

  public void GetDamage(float damage)
  {
    m_hp -= damage;
  }
}
