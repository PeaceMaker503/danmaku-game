behavior circle()
{
	let a:float = x;
	move(speed=x);
	loop(1000)
	{
		a = a + 1;
		move(angle=a);
		delay(0.01);
	}
}

make(type="RED_KNIFE", speed=0, angle=270, position=[200, 200]) with circle();




