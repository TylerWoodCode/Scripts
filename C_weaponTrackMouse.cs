//Tyler Wood
//https://www.TylerWoodCode.com
//TylerWoodCode@gmail.com

//Script that allows a weapon equipped by the player to follow the direction and aim of mouse movements.  This enables projectile weapons to fire towards the mouse.
public class weaponTrackMouse{

private GameObject theleftarm;
private GameObject therightarm;

public int equipped_shot = 1;

public int rotationOffset;
public float rotZ;

//two dimensional
private bool facingright = true;
public bool facingleft = false;
	
public Sprite characterleft;
public Sprite characterright;

public Sprite charactergunleft;
public Sprite charactergunright;

//character components
private Transform body;
private Transform rightarm;
private Transform leftarm;
	



void rotatebow () {
	//subtracting the position of the player from the mouse position
	Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
	difference.Normalize (); //normalizing the vector. Meaning that all the sum of the vector will be equal to 1
		
	rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg; //find the angle in degrees
		

	//right side
	if(rotZ <= 90f && rotZ >= -90){
			
		if(facingright == false){
			facingright = true;
			facingleft = false;
			transform.FindChild("etc").FindChild("rightarm").FindChild("charactergun").GetComponent<SpriteRenderer>().sprite = charactergunright;

			characteranimation.idler = true;
			characteranimation.idlel = false;

			characteranimation.moveleft = false;
			characteranimation.moveright = false;
		}
	}



	//left side
	else{

		if(facingleft == false){
			facingleft = true;
			facingright = false;

			transform.FindChild("body").GetComponent<SpriteRenderer>().sprite = characterleft;
			characteranimation.idlel = true;
			characteranimation.idler = false;
				
			characteranimation.moveright = false;
			characteranimation.moveleft = false;
		}
	}
		




	//~~~~~~~~~~~~~~~~~~AIMING~~~~~~~~~~~~~~~~~~
	//Debug.Log (rotZ);
	if(equipped_shot == 1){
		
		if(rotZ <= 30f && rotZ >= -30f){
			therightarm.transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
		}else if(rotZ < -30f && rotZ >= -90f){
			rotZ = -30f;
			therightarm.transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
		}else if(rotZ <= 90f && rotZ > 30f){
			rotZ = 30f;
			therightarm.transform.rotation  = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
		}
		



		//left side
		else if (rotZ >= 150f && rotZ <= 180f) {
			theleftarm.transform.rotation  = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
		} else if (rotZ <= -150f && rotZ >= -180f) {
			theleftarm.transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
		} else if (rotZ < 150f && rotZ > 90f) {
			rotZ = 150f;
			theleftarm.transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
		} else if (rotZ > -150f && rotZ < -90f) {
			rotZ = -150f;
			theleftarm.transform.rotation = Quaternion.Euler (0f, 0f, rotZ + rotationOffset);
		}
	}
}


}