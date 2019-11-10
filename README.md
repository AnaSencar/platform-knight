# platform-knight
Platform adventure game

-2D platform adventure game.\
-Using tilemap for creating scene.\
-Player character can move, jump and attack.\
-Player character can have multiple attack types made with scriptable objects.\
-Player is having health and mana, where mana is consumed when special type of attack is used.\
-Player is having ability to heal up.\
-Cinemachine is used for camera following player where world end (world borders) are defined by searching for polygon collider as bounding shape.\
-Enemy characters can move in any direction defined by vector.\
-Enemy characters can walk either on ground level, on platform or they can rotate around the platform, all of the walks are implemented by raycasting.\
-Enemy characters will follow or attack player character when in defined range and only if in viewable area which is done by using raycasting.\
-Enemy characters can be either melee or ranged type, or as enemy that cant attack but does damage if you run into it.\
-Both enemy and the player are having basic stats where it's health/mana and similar is defined.\
-Killing enemy grants u coins and/or mana.\
-Player can swap scenes by going through portal, after going through it it will start fading in and out as new scene loads. Player movement and attack is disabled while player character is going through scenes.\
-There are hazards like spikes that can dmg player character when it walks over them and they are pushing player back (bouncing).\
-Player, canvas, cameras etc. are instantiated as game starts and they persist through scenes.\
-Player can upgrade abilities that he has, like attack damage, in upgrade screen, which is opening by pressing I key. For the duration that upgrade screen is up, game is paused.
