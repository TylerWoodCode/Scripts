//Tyler Wood
//https://www.TylerWoodCode.com
//TylerWoodCode@gmail.com

//Script for monster artificial intelligence.  The monster is able to chase and attack the player.
public class monsterAI{

//statistics
public int hp;
public int speed;
public int backspeed;
public int backleapspeed;
public float cd_backleap;

public GameObject thegrave;	

private Vector3 Playertarget;
private Vector2 Playerdirection;
private float Xdif;
private float Ydif;

public int start_dist;
public int min_dist;
public int mid_dist;
public int max_dist;
public int aggromaxrange;


private bool aggrod;
private bool still;
private bool backed;
private bool backedleap;

private GameObject fx_dash;

//how much damage AI takes
public int dmgfrombow = 1;
public int dmgfromstaff = 1;

private int c_backed = 0;

//status
private bool stunned = false;
private bool stuncheck = true;	
public float stun_dur;

private int rrange;
	
private Transform t1;
private Transform t2;
//public float attentiveness;


//resume attack
void endstun(){ stunned = false;  stuncheck = true; 
		transform.Find("bow_mob").GetComponent<Bow_mob>().setshoot(true);
		t1.gameObject.SetActive (false);
}


void endt2(){  
		t2.gameObject.transform.SendMessage("off");	
}


//throttle the update to 1/10 of a second
void Start(){ InvokeRepeating ("checkin", 0, 0.2f);  t1 = transform.FindChild ("daze"); t2 = transform.FindChild ("daze2"); fx_dash = transform.FindChild("dasheffect").gameObject;}




//updating movement to mob
void Update () {
		//Debug.Log ("range:  " + rrange + "       " + aggrod);

		if(stunned == true){
			if(stuncheck == true){
				stuncheck = false;
				Invoke ("endstun", stun_dur);
				Invoke ("endt2", .2f);
				t1.gameObject.SetActive (true);
				t2.gameObject.SetActive (true);
				return;}
			
			else{ return;}
		}

		else if(still == true){ return;}
		else if(aggrod == true){  GetComponent<Rigidbody2D>().AddForce ((Playerdirection.normalized) * speed);}
		else if(backed == true){  GetComponent<Rigidbody2D>().AddForce (-(Playerdirection.normalized) * speed * backspeed/4);}
		else if(backedleap == true){ if(c_backed == 0){ Invoke ("tog_c_backed_0", cd_backleap); backedleap = false; fx_dash.gameObject.SetActive(true); Invoke ("flip_up_f", 0.5f); GetComponent<Rigidbody2D>().AddForce (-(Playerdirection.normalized) * speed * backspeed*backleapspeed); c_backed = 1;}}
	}


	private void flip_up_f(){
		fx_dash.gameObject.SetActive(false);
	}

	private void tog_c_backed_0(){
	c_backed = 0;
	}


	//checks range between mob and player
	void checkin(){

		if(stunned == true){ return;}

		//target player
		Playertarget = GameObject.Find("Player").transform.position;
			

		//mob moves towards player direction
		Xdif = Playertarget.x - transform.position.x;
		Ydif = Playertarget.y - transform.position.y;
			
		Playerdirection = new Vector2 (Xdif, Ydif);



		int rrangex = (int)transform.position.x - (int)Playertarget.x;
		int rrangey = (int)transform.position.y - (int)Playertarget.y;
		rrange = (rrangex * rrangex) + (rrangey * rrangey);
		//Debug.Log ("range:  " + rrange + "       ");


		//chase the player around
		if(rrange < aggromaxrange){

			if(rrange >= mid_dist && rrange < max_dist){ clearaggro(); aggrod = true; transform.Find("bow_mob").GetComponent<Bow_mob>().setshoot(true); return;}
			else if(rrange >= start_dist && rrange < min_dist){ clearaggro(); backed = true; transform.Find("bow_mob").GetComponent<Bow_mob>().setshoot(true); return;}
			else if(rrange >= min_dist && rrange <= mid_dist){aggrod = false; transform.Find("bow_mob").GetComponent<Bow_mob>().setshoot(true); return;}
			else if(rrange >= max_dist){ clearaggro(); transform.Find("bow_mob").GetComponent<Bow_mob>().setshoot(false); return;}
			else if(rrange < min_dist){ clearaggro(); backedleap = true; transform.Find("bow_mob").GetComponent<Bow_mob>().setshoot(false); return;}

		}
}




//stop chasing player
private void clearaggro(){
		if(aggrod == true){ aggrod = false; return;}
		else if(still == true){ still = false; return;}
		else if(backed == true){ backed = false; return;}
		else if(backedleap == true){ backedleap = false; return;}
 }




	
//player hits with melee attack
void staffhit(){
		
		hp -= dmgfromstaff;
		
		//Debug.Log (gameObject.name + "  takes damage..    HP |" + hp + "|");
		
		//death
		if(hp <= 0){ 
			thegrave.gameObject.SetActive(true);
			thegrave.gameObject.transform.parent = this.gameObject.transform.parent;
			Destroy(this.gameObject);
		}
}
	
	
	


	
//player hits with bow attack
void bowhit(){

		transform.Find("bow_mob").GetComponent<Bow_mob>().setshoot(false); 

		//hp -= dmgfrombow;
		
		stunned = true;

		//Debug.Log (gameObject.name + "  takes damage..    HP |" + hp + "|");
		
		if(hp <= 0){ Destroy(this.gameObject);}
}


}