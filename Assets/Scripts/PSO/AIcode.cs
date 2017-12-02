using UnityEngine;
using System.Collections;

public class AIcode : MonoBehaviour {
	public Transform target;
	public Transform[] ghosts ;
	public float speed = 0.4f;
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 indBest = getIndividualBestNumber ();
		float dx = transform.position.x + 0.5f * Random.value * (indBest.x - transform.position.x) + 5 * Random.value * (target.position.x - transform.position.x);
		float dy = transform.position.y + 0.5f * Random.value * (indBest.y - transform.position.y) + 5 * Random.value * (target.position.y - transform.position.y);
		Vector3 dest = new Vector2 (transform.position.x+dx,transform.position.y+dy);
		if(dest.x<0f)
		{
			dest.x=0f;
		}
		if (dest.x > 28f) {
			dest.x=28f;
		}
		if(dest.y<-7.5f)
		{
			dest.y=-7.5f;
		}
		if(dest.y>20.19f)
		{
			dest.y=20.19f;
		}
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		GetComponent<Rigidbody2D>().MovePosition(p);

		Vector3 dir =  dest- transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}
	Vector3 getIndividualBestNumber()
	{
		Vector3 best = new Vector3(Mathf.Abs(target.position.x-transform.position.x),Mathf.Abs(target.position.y-transform.position.y));
		Vector3 bestPoint = transform.position;
		for(int i = 0 ; i<ghosts.Length;i++)
		{
			Vector3 point = new Vector3(Mathf.Abs(target.position.x-ghosts[i].position.x),Mathf.Abs(target.position.y-ghosts[i].position.y));
			if(best.x>point.x && best.y>point.y)
			{
				best=point;
				bestPoint=ghosts[i].position;
			}
		}
		return bestPoint; 
	}
	void OnTriggerEnter2D(Collider2D co) {
		if (co.name == "pacman")
			Destroy(co.gameObject);
	}
}
