behavior turn(r:float, fAngle:float)
{
	delay(1);
	loop(180)
	{
		fAngle = fAngle + 1;
		move(angle= fAngle + 180, position=[200 + r*cos(fAngle), 200 + r*sin(fAngle)]);
		delay(0.01);
	}
}


var fAngle:float = 0;
var nbPart:float = 10;
var r:float = 100;
loop(nbPart)
{
	make(type= "RED_KNIFE", speed = 0, angle= fAngle + 180, position=[200 + r*cos(fAngle), 200 + r*sin(fAngle)]) with turn(r, fAngle);
	fAngle = fAngle + 36;
}