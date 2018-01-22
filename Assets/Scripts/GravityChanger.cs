using System.Collections;
using UnityEngine;

public class GravityChanger : MonoBehaviour {

    public SpriteRenderer SpriteRednerer;
    public LayerMask GroundMask;
    public Transform[] GroundCheck;

	public GameObject[] GhostsGameObjects;
	public SpriteRenderer[] GhostsSpriteRenderers;
	public ScrollingBackground ObstaclesScrollingBackgrounds;

	public ParticleSystem LowerParticleSystem;
	public ParticleSystem HigherParticleSystem;

	public static bool started = false;

    private Rigidbody2D rb;
    private bool grounded = false;
    private float groundRadius = 0.2f;

	private Coroutine ghostsCoroutine = null;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
    void FixedUpdate()
    {
        
		if(grounded = Physics2D.OverlapCircle(GroundCheck[SpriteRednerer.flipY ? 1 : 0].position, groundRadius, GroundMask))
		{
			if(SpriteRednerer.flipY)
			{
				if(LowerParticleSystem.emission.enabled)
				{
					var emission = LowerParticleSystem.emission;
					emission.enabled = false;
				}

				if (!HigherParticleSystem.emission.enabled)
				{
					var emission = HigherParticleSystem.emission;
					emission.enabled = true;
				}
			}
			else
			{
				if (!LowerParticleSystem.emission.enabled)
				{
					var emission = LowerParticleSystem.emission;
					emission.enabled = true;
				}

				if (HigherParticleSystem.emission.enabled)
				{
					var emission = HigherParticleSystem.emission;
					emission.enabled = false;
				}
			}
		}
		else
		{
			if (LowerParticleSystem.emission.enabled)
			{
				var emission = LowerParticleSystem.emission;
				emission.enabled = false;
			}

			if (HigherParticleSystem.emission.enabled)
			{
				var emission = HigherParticleSystem.emission;
				emission.enabled = false;
			}
		}
	}

	// Update is called once per frame
	void Update ()
    {
		if(started)
		{
			if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
			{
				RevertGravity();
			}
		}

		for(int i = 0; i < GhostsGameObjects.Length; i++)
		{
			if(GhostsGameObjects[i].activeSelf)
				GhostsGameObjects[i].transform.Translate(ObstaclesScrollingBackgrounds.ScrollingSpeed * (-1) * Time.deltaTime, 0f, 0f);
		}
	}

    public void RevertGravity()
    {
        if(grounded)
        {
            rb.velocity = Vector2.zero;
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, Physics2D.gravity.y * -1);
            SpriteRednerer.flipY = !SpriteRednerer.flipY;

			if(ghostsCoroutine != null)
			{
				StopCoroutine(ghostsCoroutine);
			}

			ghostsCoroutine = StartCoroutine(ghostsCoroutineMethod());
        }
    }

	private IEnumerator ghostsCoroutineMethod()
	{
		for(int i = 0; i < GhostsGameObjects.Length; i++)
		{
			GhostsGameObjects[i].transform.position = this.transform.position;
			GhostsGameObjects[i].transform.rotation = this.transform.rotation;
			GhostsSpriteRenderers[i].sprite = this.SpriteRednerer.sprite;
			GhostsGameObjects[i].SetActive(true);

			yield return new WaitForSeconds(0.15f);
		}
	}
}
