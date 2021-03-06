//Tyler Wood
//https://www.TylerWoodCode.com
//TylerWoodCode@gmail.com

//Script for rewarding the player after a completed game with visual effects.
public class starReward{

public GameObject lifestuff;
	
public float fhofftime;

//game status
public GameObject thewonlogo;
public GameObject thelostlogo;

public GameObject starspriter1;
public GameObject starspriter2;
public GameObject starspriter3;

public GameObject theshine1;
public GameObject theshine2;
public GameObject theshine3;

public GameObject theshine11;
public GameObject theshine22;
public GameObject theshine33;

//gem visuals
public GameObject fakeg1;
public GameObject fakeg2;
public GameObject fakeg3;
public GameObject fakeg4;

public GameObject thestarparticle1;
public GameObject thestarparticle2;
public GameObject thestarparticle3;

public GameObject fgemstuff;

public GameObject pointdisplayer;
public GameObject statusscorer;
public GameObject highscorer;

private Animator anim1;
private Animator anim2;
private Animator anim3;
	
public static bool cont = false;

public float starrevealdelay;
	
public GameObject thestarsbg;
public GameObject thefadedbg;
	
public float moveondelay;	

public GameObject star1;
public GameObject star2;
public GameObject star3;

//heart visuals
public GameObject thefakeheart1;
public GameObject thefakeheart2;
public GameObject thefakeheart3;

public GameObject thefakehearttick1;
public GameObject thefakehearttick2;
public GameObject thefakehearttick3;

public GameObject thefakestartick1;
public GameObject thefakestartick2;
public GameObject thefakestartick3;

public GameObject starsoundobj1;
public GameObject starsoundobj2;
public GameObject starsoundobj3;
	
private AudioSource starsound1;
private AudioSource starsound2;
private AudioSource starsound3;
	
public GameObject star1o;
public GameObject star2o;
public GameObject star3o;
	
public static int lifehp = 3;
	
private static Vector3 pos1;
private static Vector3 pos2;
private static Vector3 pos3;
	
private static float xwidth;
private static float screenwidth1;
private static float screenheight1;
	
	
	
//initialization
void Start () {

	theshine1.GetComponent<ParticleSystem>().Play();
	theshine2.GetComponent<ParticleSystem>().Play();
	theshine3.GetComponent<ParticleSystem>().Play();
	theshine1.GetComponent<ParticleSystem>().enableEmission = false;		
	theshine2.GetComponent<ParticleSystem>().enableEmission = false;		
	theshine3.GetComponent<ParticleSystem>().enableEmission = false;		
	theshine1.GetComponent<ParticleSystem>().Clear();
	theshine2.GetComponent<ParticleSystem>().Clear();
	theshine3.GetComponent<ParticleSystem>().Clear();
		
	starsound1 = starsoundobj1.GetComponent<AudioSource>();
	starsound2 = starsoundobj2.GetComponent<AudioSource>();
	starsound3 = starsoundobj3.GetComponent<AudioSource>();
		
	anim1 = star1.GetComponent<Animator>();
	anim2 = star2.GetComponent<Animator>();
	anim3 = star3.GetComponent<Animator>();
		
	//dimension calculations
	screenwidth1 = Screen.width - Screen.width/4;
	screenheight1 = Screen.height/2 + Screen.height/10;
		
	xwidth = Screen.width/4;
	//Debug.Log(xwidth);
		
	pos1 = Camera.main.ScreenToWorldPoint(new Vector3(screenwidth1 - xwidth*2, screenheight1, 10));
	pos2 = Camera.main.ScreenToWorldPoint(new Vector3(screenwidth1 - xwidth, screenheight1, 10));
	pos3 = Camera.main.ScreenToWorldPoint(new Vector3(screenwidth1, screenheight1, 10));
		
		
	star1.gameObject.transform.position = pos1;
	star2.gameObject.transform.position = pos2;
	star3.gameObject.transform.position = pos3;
		
	star1o.gameObject.transform.position = pos1;
	star2o.gameObject.transform.position = pos2;
	star3o.gameObject.transform.position = pos3;
}
	
	
	
	
	
//toggle the life stars
public void takehit(){
		
	//shatter animations
	if(lifehp == 3){
		anim1.SetBool("shatter", true);
	}
		
	if(lifehp == 2){
		anim2.SetBool("shatter", true);
	}
		
	if(lifehp == 1){
		anim3.SetBool("shatter", true);
	}
		
	--lifehp;
		
	if(lifehp == 0){
		Debug.Log("GAMEOVER");
		anim3.SetBool("shatter", true);
		Invoke("delhearts", 1f);
	}
}
	
	
	
//clean up animations
private void delhearts(){
	star1.transform.GetComponent<SpriteRenderer>().enabled = false;
	star2.transform.GetComponent<SpriteRenderer>().enabled = false;
	star3.transform.GetComponent<SpriteRenderer>().enabled = false;
		
	anim1.SetBool("shatter", false);
	anim2.SetBool("shatter", false);
	anim3.SetBool("shatter", false);
		
}
	
	
	
	
	
//delay
private void del(){
	thestarsbg.SetActive(true);
	thestarsbg.SendMessage("statuswidgetson");
}




//show the star rewards
public void showem(int x){


if(ball.trackhp == 0){
	thewonlogo.SetActive(false);
	thelostlogo.SetActive(true);
	thelostlogo.SendMessage("resetit");
}else{
	thewonlogo.SetActive(true);
	thewonlogo.SendMessage("resetit");
	thelostlogo.SetActive(false);
}


	statusscore.temp = pointdisplay.temp;
	//Debug.Log("gemcounts:  " + mapper.trackgem1 + "  " + mapper.trackgem2 + "  " + mapper.trackgem3 + "  " + mapper.trackgem4);

	paddle.paused = true;

	//clear (reset) the stars beforehand
	clearem();

	statusscorer.SetActive(true);
	statusscorer.SendMessage("updatepoints");

	thefadedbg.SetActive(true);

	star1o.SetActive(true);
	star2o.SetActive(true);
	star3o.SetActive(true);

	cont = true;

	statusscore.finaltemp = pointdisplay.temp;

		//zero stars
		if (x == 0) {
			Invoke ("playstartick1", starrevealdelay * 1);
			Invoke ("playstartick2", starrevealdelay * 2);
			Invoke ("playstartick3", starrevealdelay * 3);
		} else { //stars to display
			if (x >= 1) {
				Invoke ("del1", starrevealdelay * 1);
				Invoke ("playstartick1", starrevealdelay * 1);
				statusscore.finaltemp += 100000;
			}
			if (x >= 2) {
				Invoke ("del2", starrevealdelay * 2);
				Invoke ("playstartick2", starrevealdelay * 2);
				statusscore.finaltemp += 100000;
			}
			if (x >= 3) {
				Invoke ("del3", starrevealdelay * 3);
				Invoke ("playstartick3", starrevealdelay * 3);
				statusscore.finaltemp += 100000;
			}
		}


	Invoke ("delgemstart", starrevealdelay * 4);
	Invoke("del", moveondelay);


	for(int ok = 0; ok < mapper.trackgem1; ++ok){ statusscore.finaltemp += 10000;}
	for(int ok = 0; ok < mapper.trackgem2; ++ok){ statusscore.finaltemp += 10000;}
	for(int ok = 0; ok < mapper.trackgem3; ++ok){ statusscore.finaltemp += 10000;}
	for(int ok = 0; ok < mapper.trackgem4; ++ok){ statusscore.finaltemp += 10000;}

	//Debug.Log(statusscore.finaltemp);

	pointdisplayer.SendMessage("checkhighscore", levellocks.leveljustattempted);
}



private void delgemstart(){
	if(ball.trackhp == 0){fgemstuff.SendMessage("startem");}
}



//star effect
private void playstartick1(){

	thefakestartick1.SendMessage ("setitup");
	 
	if(ball.trackhp < 1){
		thefakestartick1.gameObject.transform.FindChild("misstxt").gameObject.SetActive(true);
		thefakestartick1.gameObject.transform.FindChild("misstxt").gameObject.transform.SendMessage("resetit");
	}
}


//star effect
private void playstartick2(){

	thefakestartick2.SendMessage ("setitup");

	if(ball.trackhp < 2){
		thefakestartick2.gameObject.transform.FindChild("misstxt").gameObject.SetActive(true);
		thefakestartick2.gameObject.transform.FindChild("misstxt").gameObject.transform.SendMessage("resetit");
	}
}


//star effect
private void playstartick3(){

	thefakestartick3.SendMessage ("setitup");

	if(ball.trackhp < 3){
		thefakestartick3.gameObject.transform.FindChild("misstxt").gameObject.SetActive(true);
		thefakestartick3.gameObject.transform.FindChild("misstxt").gameObject.transform.SendMessage("resetit");
	}
}






//activate "fake" hearts for visual
private void del11(){

	if(cont == true){

		if(ball.trackhp == 3){
			thefakehearttick1.SendMessage ("setitup");
			fakeheart1.moving = true;
			Invoke("fhoff1", fhofftime);
		}

		if(ball.trackhp == 2){
			thefakehearttick2.SendMessage ("setitup");
			fakeheart2.moving = true;
			Invoke("fhoff2", fhofftime);
		}

		if(ball.trackhp == 1){
			thefakehearttick3.SendMessage ("setitup");
			fakeheart3.moving = true;
			Invoke("fhoff3", fhofftime);
		}

		lifestuff.SendMessage("takehit");
	}
}




//second delay
private void del22(){

	if(cont == true){

		if(ball.trackhp == 3){
			thefakehearttick2.SendMessage ("setitup");
			fakeheart2.moving = true;
			Invoke("fhoff2", fhofftime);
		}
		
		if(ball.trackhp == 2){
			thefakehearttick3.SendMessage ("setitup");
			fakeheart3.moving = true;
			Invoke("fhoff3", fhofftime);
		}

		lifestuff.SendMessage("takehit");
	}
}



//third delay
private void del33(){

	if(cont == true){

		if(ball.trackhp == 3){
			thefakehearttick3.SendMessage ("setitup");
			fakeheart3.moving = true;
			Invoke("fhoff3", fhofftime);
		}	

		lifestuff.SendMessage("takehit");
	}
}







//ACTIVATE STARS
//first delay
private void del1(){

	if(cont == true){

		if(ball.trackhp == 1){fgemstuff.SendMessage("startem");}

		if(screenshaker.shakecheck == false){
			screenshaker.shakecheck = true;
			screenshaker.screenshaking = true;
		}

		star1.SetActive(true);
		star1.gameObject.transform.FindChild("fakeheartonstar").gameObject.transform.SendMessage("resetit");

		statusscore.temp += 100000;
		statusscorer.SendMessage("updatepoints");
		theshine1.SendMessage("startit");		
		theshine11.SendMessage("startit");		
		
		starspriter1.SendMessage("gogrow");

		if(mapper.soundcheck == 1){	
			starsound1.Play();
		}
	}
}




//second delay
private void del2(){

	if(ball.trackhp == 2){fgemstuff.SendMessage("startem");}
		if(cont == true){
			if(screenshaker.shakecheck == false){
				screenshaker.shakecheck = true;
				screenshaker.screenshaking = true;
			}
		
		star2.SetActive(true);
		star2.gameObject.transform.FindChild("fakeheartonstar").gameObject.transform.SendMessage("resetit");

		statusscore.temp += 100000;
		statusscorer.SendMessage("updatepoints");
		theshine2.SendMessage("startit");		
		theshine22.SendMessage("startit");		

		starspriter2.SendMessage("gogrow");

		if(mapper.soundcheck == 1){	
			starsound2.Play();
		}
	}
}



//third delay
private void del3(){

	if(cont == true){
		if(ball.trackhp == 3){fgemstuff.SendMessage("startem");}
			if(screenshaker.shakecheck == false){
				screenshaker.shakecheck = true;
				screenshaker.screenshaking = true;
			}
		
		star3.SetActive(true);
		star3.gameObject.transform.FindChild("fakeheartonstar").gameObject.transform.SendMessage("resetit");

		statusscore.temp += 100000;
		statusscorer.SendMessage("updatepoints");
		theshine3.SendMessage("startit");		
		theshine33.SendMessage("startit");		

		starspriter3.SendMessage("gogrow");

		if(mapper.soundcheck == 1){	
			starsound3.Play();
		}
	}
}
		


	




//clear (reset) the stars completely for a fresh go
public void clearem(){
	//Debug.Log("clearem");
	pointdisplay.itsahigh = false;

	statusscorer.SetActive(false);
	highscorer.SetActive(false);

	thestarsbg.SetActive(false);
		
	star1o.SetActive(false);
	star2o.SetActive(false);
	star3o.SetActive(false);

	star1.SetActive(true);
	star2.SetActive(true);
	star3.SetActive(true);

	star1.SendMessage("togoff");
	star2.SendMessage("togoff");
	star3.SendMessage("togoff");


	star1o.SetActive(true);
	star2o.SetActive(true);
	star3o.SetActive(true);

	star1o.SendMessage("resetit");
	star2o.SendMessage("resetit");
	star3o.SendMessage("resetit");


	thefakeheart1.SendMessage("resetit");
	thefakeheart2.SendMessage("resetit");
	thefakeheart3.SendMessage("resetit");


	thefadedbg.SetActive(true);
	thefadedbg.transform.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);
	thefadedbg.SendMessage("resetit");
	thefadedbg.SetActive(false);


	star1.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
	star2.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
	star3.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);

	star1o.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
	star2o.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
	star3o.transform.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);


	star1.SetActive(false);
	star2.SetActive(false);
	star3.SetActive(false);

	star1o.SetActive(false);
	star2o.SetActive(false);
	star3o.SetActive(false);


	thefakeheart1.gameObject.transform.GetComponent<ParticleSystem>().enableEmission = false;
	thefakeheart1.gameObject.transform.GetComponent<ParticleSystem>().Stop();
	thefakeheart1.gameObject.transform.GetComponent<ParticleSystem>().Clear();
	

	thefakeheart2.gameObject.transform.GetComponent<ParticleSystem>().enableEmission = false;
	thefakeheart2.gameObject.transform.GetComponent<ParticleSystem>().Stop();
	thefakeheart2.gameObject.transform.GetComponent<ParticleSystem>().Clear();
		

	thefakeheart3.gameObject.transform.GetComponent<ParticleSystem>().enableEmission = false;
	thefakeheart3.gameObject.transform.GetComponent<ParticleSystem>().Stop();
	thefakeheart3.gameObject.transform.GetComponent<ParticleSystem>().Clear();	

	cont = false;
}


	


private void fhoff1(){
	fakeheart1.moving = false;
	thefakeheart1.gameObject.transform.GetComponent<ParticleSystem>().enableEmission = false;
	thefakeheart1.gameObject.transform.GetComponent<ParticleSystem>().Stop();
}


private void fhoff2(){
	fakeheart2.moving = false;
	thefakeheart2.gameObject.transform.GetComponent<ParticleSystem>().enableEmission = false;
	thefakeheart2.gameObject.transform.GetComponent<ParticleSystem>().Stop();
}


private void fhoff3(){
	fakeheart3.moving = false;
	thefakeheart3.gameObject.transform.GetComponent<ParticleSystem>().enableEmission = false;
	thefakeheart3.gameObject.transform.GetComponent<ParticleSystem>().Stop();
}


	
	
	
	
}
