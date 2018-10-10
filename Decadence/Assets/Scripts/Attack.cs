using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
  private float m_damage;
  private BreakObject m_breakScript;

  // Use this for initialization
  void Start()
  {
    m_damage = 1;
    m_breakScript = null;
  }

  // Update is called once per frame
  void Update()
  {
    // If m_breakScript isn't null and Q key is pressed GetDamage is called
    if(m_breakScript) {
      if (Input.GetKeyDown(KeyCode.Q)) {
        m_breakScript.GetDamage(m_damage);
        m_breakScript = null;
      }
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    // If the player touches a breakable object it gets the script so it can call GetDamage
    if(collision.gameObject.tag=="Breakable") {
      m_breakScript = collision.gameObject.GetComponent<BreakObject>();
    }
  }

  private void OnCollisionExit(Collision collision)
  {
    // If the player is no longer in contact with a breakable object m_breakScript is null
    m_breakScript = null;
  }
}
