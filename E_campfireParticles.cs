//Tyler Wood
//https://www.TylerWoodCode.com
//TylerWoodCode@gmail.com

//Script for campfire particle behavior, featuring 6 different particle effects simultaneously.
public class campfireParticles{

private Animator anim;

public GameObject thesmoke;
public GameObject thecrackle;
public GameObject thecrackle2;
public GameObject thepuff;
public GameObject thepop;
public GameObject extinguishpop;

public static bool campfirelit = false;


//initialization
void Start(){
	anim = this.gameObject.transform.GetComponent<Animator>();
}
	
	

//call to light up the campfire from unlit state
public void lightit(){

	if(campfirelit == false){ 
		anim.SetBool("lightcampfire", true);

		//particle objects activated
		thesmoke.SetActive(true);
		thecrackle.SetActive(true);
		thecrackle2.SetActive(true);
		thepop.SetActive(true);
		
		thepuff.GetComponent<ParticleSystem>().enableEmission = true;
		thesmoke.GetComponent<ParticleSystem>().enableEmission = true;
		thecrackle.GetComponent<ParticleSystem>().enableEmission = true;
		thecrackle2.GetComponent<ParticleSystem>().enableEmission = true;

		//play the various particles
		thesmoke.GetComponent<ParticleSystem>().Play();
		thecrackle.GetComponent<ParticleSystem>().Play();
		thecrackle2.GetComponent<ParticleSystem>().Play();
		thesmoke.GetComponent<ParticleSystem>().Play();
			
		thesmoke.GetComponent<Light>().enabled = true;

		thepop.GetComponent<ParticleSystem>().enableEmission = true;
		thepop.GetComponent<ParticleSystem>().Play();


		//randomly puff smoke from fire
		float x = Random.Range(10, 20);
		Invoke("puff", x);
		campfirelit = true;
	}
}



//disable the pop visual effect
public void dispop(){

	thepuff.GetComponent<ParticleSystem>().enableEmission = false;
	thepuff.GetComponent<ParticleSystem>().Stop();
	thepuff.GetComponent<ParticleSystem>().Clear();

	thepuff.SetActive(false);

}





//call to unlight up the campfire from lit state
public void unlightit(){

	if(campfirelit == true){
		anim.SetBool("lightcampfire", false);

		thesmoke.SetActive(false);
		thecrackle.SetActive(false);
		thecrackle2.SetActive(false);
		thepuff.SetActive(false);
		
		
		thesmoke.GetComponent<Light>().enabled = false;

		thepuff.GetComponent<ParticleSystem>().enableEmission = false;
		thesmoke.GetComponent<ParticleSystem>().enableEmission = false;
		thecrackle.GetComponent<ParticleSystem>().enableEmission = false;
		thecrackle2.GetComponent<ParticleSystem>().enableEmission = false;


		if(campfirelit == true){
			extinguishpop.GetComponent<ParticleSystem>().enableEmission = false;
			extinguishpop.GetComponent<ParticleSystem>().enableEmission = true;
			extinguishpop.GetComponent<ParticleSystem>().Play();
		}

	campfirelit = false;

	}
}
	





//the puff visual effect, random timed recursion
private void puff(){

	if(campfirelit == true){
		float x = Random.Range(10, 20);
		Invoke("puff", x);

		Invoke ("unpuff", x + 2);

		thepuff.SetActive(true);
		thepuff.GetComponent<ParticleSystem>().enableEmission = true;
		thepuff.GetComponent<ParticleSystem>().Play();

	}
}



//stop the puff visual effect
private void unpuff(){

	if(campfirelit == false){
		thepuff.GetComponent<ParticleSystem>().enableEmission = false;

	}
}


}
