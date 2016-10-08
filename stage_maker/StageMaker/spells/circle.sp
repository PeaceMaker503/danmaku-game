let angle1 0;
let angle2 180;
let angle3 90;
let angle4 270;
loop 1440
{
	with speed 1;
	with angle angle1;
	with type RED_KNIFE;
	make;

	with speed 1;
	with angle angle2;
	with type RED_KNIFE;
	make;

	with speed 1;
	with angle angle3;
	with type BLUE_KNIFE;
	make;

	with speed 1;
	with angle angle4;
	with type BLUE_KNIFE;
	make;

	delay 0.2;
	add angle1 angle1 18;
	add angle2 angle2 18;
	sub angle3 angle3 18;
	sub angle4 angle4 18;
}
free angle1;
free angle2;
free angle3;
free angle4;