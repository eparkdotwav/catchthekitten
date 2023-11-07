code written by: epark
github link: https://github.com/eparkdotwav
made in november 2023

this project is a game i made in unity with c# called catch the kitten
catch the kitten is a game that is reliant on listening to sound in order to play it; it utilizes various skills like loading new screens, handling collisions, playing sounds, using canvas ui elements, using player prefs to save best time, having sprite animations, using a particle system, and updating game objects dynamically.

upon opening the build, a player must click start on the menuscreen.
they will then be taken to the main screen, where they spawn as my cat, sarang.
the main objective of the game is to find the hidden kitten and get the best time possible. as the kitten gets closer to sarang, her meows get louder, but as she gets farther away, her meows get softer. if they're too far apart, then the meows disappear completely until sarang finds the kitten.
players navigate through the game as my cat, sarang, using the arrow keys to move her around the screen. when sarang finally finds the kitten, it appears on the screen, and a particle system appears. after two seconds, the game then returns the player to the main screen again, updating the best time if the player has beaten the record.
the player can escape the game by pressing escape any time. pressing escape while in game will take the player to the menu screen, and pressing escape while on the menu screen will then exit the game.