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
	void Update () {
		Vector3 indBest = getIndividualBestNumber ();
		float dx = transform.position.x + 2 * Random.value * (indBest.x - transform.position.x)+2*Random.value*(target.position.x-transform.position.x);
		float dy = transform.position.y + 2 * Random.value * (indBest.y - transform.position.y)+2*Random.value*(target.position.y-transform.position.y);
		Vector2 dest = new Vector2 (dx, dy);
		Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
		GetComponent<Rigidbody2D>().MovePosition(p);
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
}
