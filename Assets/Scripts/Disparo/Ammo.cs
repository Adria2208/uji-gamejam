using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ammo : MonoBehaviour
{
 public float seeds;
 public float maxAmmo;
 //public Ammunition AmmoBar;
 // Start is called before the first frame update

 void Start()
 {
 seeds = maxAmmo;
// AmmoBar.startAmmoBar(seeds);
 }

 public void WastedAmmo(float damage)
 {
 seeds -= damage;
 // AmmoBar.changeCurrentAmmo(seeds);
 }

  public void PickedAmmo(float damage)
 {
 seeds = damage;
 // AmmoBar.changeCurrentAmmo(seeds);
 }
}
