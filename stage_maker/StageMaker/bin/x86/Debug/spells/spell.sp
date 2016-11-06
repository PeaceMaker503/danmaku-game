behavior circle()
{
	var a:float = 270;
	move(id = "ma_part", speed=x);
	loop(1000)
	{
		a = a + 1;
		move(angle=a);
		delay(0.01);
	}
}

make(id="ma_part", type="RED_KNIFE", speed=0, angle=270, position=[200, 200]) with circle();