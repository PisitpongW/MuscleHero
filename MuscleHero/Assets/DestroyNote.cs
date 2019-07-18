using UnityEngine;

public class DestroyNote : MonoBehaviour 
{
	public GameObject explosionEffect;
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Activator")
		{
			Instantiate(explosionEffect, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
