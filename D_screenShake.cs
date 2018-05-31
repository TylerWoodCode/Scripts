//Tyler Wood
//https://www.TylerWoodCode.com
//TylerWoodCode@gmail.com

//Script for enabling screen shake to be added to the camera object.  Modifiable by altering the included parameters.
public class screenShake{
	
private bool restorexlt = false;
private bool restorexgt = false;
private bool restoreylt = false;
private bool restoreygt = false;
	
public Camera mainCamera;	

public static bool screenshaking = false;
public static bool shakecheck = false;
	
public float strength;
public float length;
		
public float xmax;
public float ymax;
	

private static bool ok = false;

//position vector for manipulation
private Vector3 pp;
	
private static Vector3 startpos;
private static Vector3 oripos;
		
private static bool check = false;
	
//temporary values
private static float s = 0;
private static float ss = 0;
	
	
	

	
void Start(){
	oripos = mainCamera.transform.position;
	Debug.Log("original position:  " + oripos);
}

	
	
	
	
	
void FixedUpdate(){

	//if any movement
	if(screenshaking == true || restorexlt == true || restorexgt == true || restoreylt == true || restoreygt == true){

		//random movement directions
		if(check == false){
			check = true;
			s = Random.Range(-10, 10);
			ss = Random.Range(-10, 10);
			//Debug.Log(ss);
		}
					
		pp = mainCamera.transform.position;
			
		if(screenshaking == true){
				
			//happens once, set up conditions
			if(ok == false){ ok = true;
				//Debug.Log("TOGGLE OFF");
				Invoke("stopshake", length);	
			}
				
				
			//horizontal shake
			if(s > 0){
				if(pp.x > (oripos.x + xmax)){
					s = -1;
				}else{  pp.x += strength;}
					
				}else{ 
					if(pp.x < (oripos.x - xmax)){
						s = 1;
					}else{ pp.x -= strength;}
				}
				
				
				//vertical shake
				if(ss > 0){
					if(pp.y > (oripos.y + ymax)){
						//Debug.Log(pp.y + "  >=  " + (oripos.y + ymax));
						ss = -1;
					}else{ pp.y += strength;}

				}else{
					if(pp.y < (oripos.y - ymax)){
						//Debug.Log(pp.y + "  <=  " + (oripos.y + ymax));
						ss = 1;
					}else{ pp.y -= strength;} 
				}
			}
			
			
			
			//restore x1 camera position
			if(restorexlt == true){		
				//Debug.Log("restorexlt   " + pp.x + "     " + oripos.x);
				
				if(pp.x == oripos.x){
					reset();
					restorexlt = false;
				}
				else{
					pp.x += 0.01f;
				}
			}
			
			//restore x2 camera position
			else if(restorexgt == true){
				//Debug.Log("restorexgt   " + pp.x + "     " + oripos.x);
				//Debug.Log(oripos.x + "       " + pp.x);

				if(pp.x == oripos.x){
					reset();
					restorexgt = false;
				}
				else{
					pp.x -= 0.01f;
				}
			}			
			
			//restore y1 position
			if(restoreylt == true){
				//Debug.Log("restoreylt");
				if(pp.y == oripos.y){
					reset();
					restoreylt = false;
				}
				else{
					pp.y += 0.01f;
				}
			}
			
			//restore y2 position
			else if(restoreygt == true){
				//Debug.Log("restoreygt");			
				if(pp.y == oripos.y){
					reset();
					restoreygt = false;
				}
				else{
					pp.y -= 0.01f;
				}
			}			
	
			
		pp.x = Mathf.Round(pp.x * 100)/100;
		pp.y = Mathf.Round(pp.y * 100)/100;
		mainCamera.transform.position = pp;
	}
}
	
	
	
	
	
//check shake variables reset
private void reset(){
	//Debug.Log("RESET");
	if(mainCamera.transform.position.x == oripos.x && mainCamera.transform.position.y == oripos.y){ 
		//Debug.Log("RESET COMPLETE");
		shakecheck = false;
		check = false;
		ok = false;
	}
}
		
	
	
	
	
//begin to stop the shaking
private void stopshake(){
	//Debug.Log("STOPSHAKE:  " + oripos.x + "       " + pp.x);
	float tx = mainCamera.transform.position.x;
	float ty = mainCamera.transform.position.y;
		
	screenshaking = false;	
		
	if(tx < oripos.x){
		restorexlt = true;
	}
	else if(tx > oripos.x){
		restorexgt = true;
	}
	if(ty < oripos.y){
		restoreylt = true;
	}
	else if(ty > oripos.y){
		restoreygt = true;
	}
		
	reset();
}


}