#Toy Robot Game – Backend (C#)

The game initialises with an empty 5 x 5 board with its own coordinate system:
the bottom left of the board is (1, 1) (row 1, column 1), and the top right corner of the board is (5, 5).
When the game starts, it responds to the following user commands:


Commands:
PLACE_ROBOT X,Y,DIRECTION[NORTH,SOUTH,EAST,WEST]
PLACE_WALL X,Y
REPORT
MOVE
LEFT
RIGHT




#Test case
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
