PLACE_WALL 1,2
PLACE_ROBOT 1,1,NORTH
REPORT   	#should print 1,1,NORTH,ROBOT
MOVE		#should print wall ahead
REPORT	#should print 1,1,NORTH,ROBOT
RIGHT		#should print 1,1,EAST,ROBOT
MOVE		
REPORT	#should print 2,1,EAST,ROBOT
MOVE		
REPORT 	#should print 3,1,EAST,ROBOT
MOVE
MOVE
REPORT	#should print 5,1,EAST,ROBOT
MOVE
REPORT	#should wrap to print 1,1,EAST,ROBOT		