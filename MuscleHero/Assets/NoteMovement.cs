using UnityEngine;

public class NoteMovement : MonoBehaviour 
{
	public Rigidbody noteObject;
	public GameObject effectWater, effectSpawn;
	public Vector3 v;
	private float cont;
	void Start()
	{
		Instantiate(effectSpawn, noteObject.transform.position, noteObject.transform.rotation);
		cont = Time.time;
	}
	void Update () 
	{
		if(Time.time - cont > 0.3f)
		{
			Instantiate(effectWater, noteObject.transform.position, noteObject.transform.rotation);
			cont = Time.time;
		}
		v = noteObject.velocity;
		v.z = -7f;
		v.x = 0f;
		noteObject.velocity = v;
	}
}
