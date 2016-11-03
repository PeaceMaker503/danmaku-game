LET_AFF(<temp0>, STRING, "RED_KNIFE")
LET_AFF(<temp1>, FLOAT, 1.0)
START_CASE(0, <temp0>, ==, <temp1>)
LET_AFF(<temp2>, STRING, "RED_K")
LET_AFF(s, STRING, <temp2>)
LET_AFF(<temp3>, STRING, s)
WITH_TYPE(<temp3>)
LET_AFF(<temp4>, FLOAT, 2)
LET_AFF(<temp5>, FLOAT, 5)
LET_AFF(<temp6>, FLOAT, MUL(<temp4>; <temp5>))
WITH_SPEED(<temp6>)
LET_AFF(<temp7>, FLOAT, 200)
LET_AFF(<temp8>, FLOAT, 200)
LET_AFF(<temp9>, FLOAT, 4.2)
LET_AFF(<temp10>, FLOAT, MUL(<temp8>; <temp9>))
LET_AFF(<temp11>, VECTOR, [<temp7>; <temp10>])
WITH_DESTINATION(<temp11>)
LET_AFF(<temp12>, FLOAT, 200)
LET_AFF(<temp13>, FLOAT, 200)
LET_AFF(<temp14>, VECTOR, [<temp12>; <temp13>])
WITH_POSITION(<temp14>)
MAKE()
LET_AFF(<temp15>, FLOAT, 5)
DELAY(<temp15>)
END_CASE(0)