let var:number 0;

loop 10
{
	mod var INDEX_0 2;
	case var == 0
	{
		call CIRCLE 0 36 2 0 10 RED_KNIFE;
	}
	delay 1;
	case var == 1
	{
		call CIRCLE 0 18 2 0.05 20 BLUE_KNIFE;
	}
	delay 1;
}
free var;