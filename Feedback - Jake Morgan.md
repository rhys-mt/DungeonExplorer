# Feedback

Jake Morgan

### Qualities

Love the theme. 

Meets the criteria of room description and getting item.

Program has well structured objects.

So far modular, id ensure you keep it as modular as you can.

Effective application of both your room and player classes.

### Improvements:

Add XML comments above functionalities

	/// <summary>
	/// summary here....
	/// </summary>

Recommend adding more validation to all your inputs.

Add a main game loop and possibly a main menu.

Line 28 - 26: This is where id consider a loop for invalid inputs or posibly a method for handling input throughout your program.

Uneccessary 'Game.Game' and so on 'X.X' can just be 'X'.

Id consider changing the 'Player' 'inventory' into a List<string> oppose to just a single item. Allowing for future implementation of a loot system.
The same could be suggested for the 'Room'.

Consider adding validation if you are changing any attributes that are necessary in the future of the program, such as the players inventory, id validate the item before adding.
This could be just checking if its a null entry.

# Checklist:

## Pass standard:
	
1. [/] The code compiles and runs.
2. [/] The player can explore at least one room.
3. [/] Object instantiation, method calls evident.
4. [?] There is code review from two students.
5. [/] Handle invalid commands gracefully without crashing the program.

## 2:2 standard:

1. [.]  Rooms can contain multiple items or monsters.
2. [.]  The Testing class is used.
3. [/]  The player can pick up items through an implementation of the
        Player.PickUpItem() method.
4. [/]  The C# style guide is followed partially.
5. [/]  At least one room has a description and can contain one item or one
	monster. These functionalities are given by the Room.GetDescription() method.
6. [/]  Method calls from ‘Main’ to methods in other classes

## 2:1 standard:

1. [?]  Pull Requests and code reviews are noted
2. [?]  You have taken account of the reviews and merging your changes.
3. [/]  There is a complete implementation of your code with no issues.
4. [/]  Commenting is mostly through the code files.
5. [/]  There are at least one Game and Player objects.
6. [?]  There is evidence of testing.
7. [/]  Error handling is performed well but there are still issues.
8. [/]  There is clear evidence of object-oriented features such as classes, object instantiation, encapsulation and methods.

## First standard:

1. [?]  You have taken effective account of the reviews by merging your
	changes or suggesting alternative approaches.
2. [?]  The video demonstrates a critical reflection and that you learned from
	the assignment’s experience.
3. [.]  The implementation is complete with excellent error handling.
4. [.]  The C# style guide is shown to be adhered to. XML documenting
	comments are throughout the code.
5. [.]  The testing class uses ‘debug.assert’ to verify aspects of the code.
6. [.]  The implementation of classes, object instantiation, encapsulation
	and methods are complete and with no issues.



