<h1>SuperScale Unity Assignment</h1>
The goal of the assignment is to create a Unity project for an Android game. Upon start, a Loading screen is presented to the player. From this screen, an overlay Leaderboards table can be opened.
<h2>Loading screen</h2>
The Loading screen contains a single “TAP TO START” button that opens the Leaderboards. The screen itself should scale properly to a wide range of screen aspect ratios (see provided Mockups)
<h2>Leaderboards</h2>
The Leaderboards screen switches between displaying a table of either 7 or 10 players. That is: when the table closes, the other table shall be loaded next time the “TAP TO START” button is pressed. Data for these tables is provided in the supplied .json files. In actual games, it would be sent by a DB “as is” for the client to parse. You can assume the JSON data will always be of the appropriate type (i.e. you don’t need to check for empty fields).

The list of players itself can be dynamic - the DB can provide anywhere between 7 and 10 players per leaderboard and so the table shall expand / shrink its size to accommodate the player list.

The opening and closing of the Leaderboards should be pleasant to the player - try to create an enjoyable visual feeling without using additional graphical assets.

Some constants that may otherwise be hard to figure out:
FrameHighlight.png
	RGBA color used is #55CCFFFF

Glow.png
	Size of the asset in UI is 880x277 px
	RGBA color used is #0059B89D
<h2>Evaluation criteria</h2>
We are interested in the quality of your code. We would like to know what kind of data structures you use and how you pass data around.

We will also compare your solution to the provided mockups, so try to be as precise as possible.
<h2>Assignment output format</h2>
Please create a .zip of the complete Unity project (without the Library folder), using Unity version 2020.3.xx or newer. Use of 3rd party assets is allowed. For example, dependency injection frameworks such as Zenject or animation tools such as DOTween can be used. But please bear in mind that we are mostly interested in your code.
