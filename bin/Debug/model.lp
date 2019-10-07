\ENCODING=ISO-8859-1
\Problem name: ILOG.CPLEX

Minimize
 obj: crew_1_0 + crew_2_1
Subject To
 day_2_route_1: crew_1_0 >= 1
 day_3_route_1: crew_1_0 >= 1
 c5:            crew_1_0  = 1
 c7:            crew_2_1  = 1
Bounds
 0 <= crew_1_0 <= 1
 0 <= crew_2_1 <= 1
End
