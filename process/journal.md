# Process Journal / To-dos

**NOTE**: This is a combined journal/to-do list I maintained in Evernote while working on the project.

**To do Monday, 18 July 2016**

Fix the navigation controls a bit so they aren’t drifty?

------
------

Tuesday, 28 June 2016

**Today:**

Import all models to correct scale with UVs and materials etc. (change snake to Artifact?)

Map the game (consider not having everything be linked? deaths as dead-ends?) (would be nice to have some navigation semantics)

Make new landscape for some variety

Create a prefab UI element to place images on

Create all UI images

Import UI images into game

Create all UI dialogs (find some smart way to scale?)

Add navigation back in

Create all landscapes and artifacts

Create all landscapes with UI dialogs (and add UIs artifact levels)

Change navigation to account for non-links (perhaps another array element with NEWS in it)

Add contemplation lights

Add constellation trigger

Draw constellations

**NOPE**Change up/down to rotate around pivot (rather than camera x)

**NOT NEEDED**Add constellation names (UI text) fade in on look?

Check basic controller support

Stars

Redraw the constellations in 5x5 space with star size matching raft

Make the constellations look more consistent with each other in terms of size, line size...

Make the constellation stars look more like the particle stars (or at least just not obvious not them)...

Position the constellations nicely

Double check they all show up

Sound

Add general wind sound

Add rushing wind sound for movement

**NO**Add contemplation completed sound

**NO**Maybe add a low guitar note (variety of) each time you find a new place? (Might get tiresome)

Make the gravestone more legible (plausibly just black text)

Make title screen

Need to move currentContemplation light to areas we return to if they’re done obvi.

**FUCK IT**Tombstone contemplation light didn’t look great

Getting some hideous flicker on some of the UIs

Some (most?) of the elements don’t fade

------

Monday, 27 June 2016

Currently: ~20 all told, 5x5 would have 5 empties, centre piece should be the tombstone? Or should be the starting point...

party names

bad water, rough trail, severe blizzard, wrong trail (possible all in one)

hijo has cholera + hijo has a fever + hijo has exhaustion + hijo has died (all in one)

jacqueline has measles

jacqueline has died

jane has dysentery + jane has died

shelley has died

independence (place)

chimney rock (place)

blue mountains (place)

the dalles (place)

map to the dalles?

BROKEN WHEEL + broken wheel ui

**RIFLE** + no food

RIVER(BED) + tipped wagon ui

ARROW + after passing the third sign

RAFT+**ROCK**? + william drowned

GRAVESTONE + all your party have died

**BONES** + oxen injured (or drowned?) [perhaps just horns coming of a plate and some suggest of ribs?

SNAKE + shelley has a snake bite

BAD WATER? (A pool)

ROUGH TRAIL? (A spiky landscape?)

BIZZARD? (Particle effects?)

FIRE? (Particle effects?)

Constellations??? UH OH. Only the objects perhaps then...

The broken wheel [A broken wheel]

The rifle [A rifle]

The riverbed (the tipped wagon?) [Could just be water pattern]

The arrow [An arrow]

The raft [Parallel lines?]

The gravestone [Stone shape]

The bones [Bones]

The snake [Snake]

That’s a nice set of constellation names… be nice if they got little captions when you looked up at them...

------

Monday, 27 June 2016

**Thinking**

Okay, so I now have a 2x2 build of the game in which:

there is a 3D model (wagon wheel) and a UI element (leader) with emission

you can rotate around terrain/object

you can navigate between each of the terrains

there is a day/night cycle along with a constant twilight

there are stars all around

if you contemplate for a full day and night a constellation appears and a light illuminates the scene

there is a torch that casts a flickering light

Those are basically all the things that make up the game proper, but now we need:

The full “narrative of the game” (i.e. a play through)

Do (yet another) play-through with screens

Names: William, Jacqueline, Hijo, Shelly

Models of all objects

Screen captures from the game as UI elements in world

All constellations

Possibly another terrain or two (e.g. if I need a riverbed)

Sound design

Constant ambient sound

Contemplation sound (either completion or cumulative)

Travel sound (rush of wind)

Controller input (PS4 okay? I assume Unity just handles this…)

UI design (information on how to play)

Title screen

The thing I have repeatedly forgotten while making this game has been that a big part of the interest/importance (from my perspective at least) is the “environmental storytelling” angle. Amazingly I’ve only just thought of calling it that now, but that’s what it is. I’ve worried the game is too static and boring, that contemplation is uninteresting, but the point is to move around and kind of recreate this tragic journey these people took into the west, dying along the way.

11:25 AM

Having done a few more playthroughs (including getting to the end and crashing the raft sufficiently many times to realise you CAN all drown that way, but with different announcements). It occurs to me that it might be nice to have UI elements in **combination** with objects sometimes. Like, the raft crashes and you lose William, could have both the raft and that death announcement… not always but just sometimes.

So the time has come to work out what the scenes are and thus what UIs and models I actually want/need.

SNAKE

WAGON WHEEL

RIFLE

RIVERBED (MULTIPLE?)

ARROW (RIVER)

RAFT (PIECES?)

GRAVESTONE FOR WILLIAM

OX BONES

???CHIMNEY ROCK

???WAGON SKELETON

???(INDEPENDENCE ROCK?)

???GENERAL SUPPLY STORE FAÇADE

??? BOOTS / HAT

Party leader – Rest of party (Two UIs together in one scene)

X has a snake bite etc.

X has died (all)

2-3 place graphics?

???A map

2-3 misfortunes

???Meagre rations

???Stren/Grueling pace

Is there any spatial relationship between the different scenes? Does a series of misfortunes “lead toward” a gravestone?

**Narrative**

So the basic narrative is: family sets off on the Oregon trail and doesn’t make it. They die along the way, with the leader William drowning on his raft down the Columbia river. They die of snake bites, cholera, dysenery, fever, etc. They have gravestones along the way along with UIs announcing their deaths? (Or just the one gravestone in fact, when I think about it? The others just die without notice in fact…)

What we learn about them is their deaths, pieces of their wagon and equipment and raft, and places they got to along the way. Because that’s all there is to an Oregon trail – there’s nothing left behind, you move along and you consume everything you have and eventually you die...

And really the key element of mysticism here is death – holy sites and shrines are generally devoted to deaths and symbolic objects, and I need to remember that. I should probably have LESS stuff not more when I think about it. A curated set of objects from a trail.

SNAKE (with snakebite UI)

(BROKEN?) WHEEL (broken wagon wheel UI?)

GUN (with meat waste UI? or even just that they failed to shoot any at all? “You were unable to shoot any food")

RIVERBED (with appropriate misfortune UI element)

???CHIMNEY ROCK (are there any other places that can be MODELLED? Does it make sense to have just one?)

OX BONES (still make sense, with ox injury UI)

GRAVESTONE (with all of your party are dead UI)

RAFT (maybe combo with WAGON? With William drowned)

???WAGON (too complex? would have gone down with the raft...)

ARROW (last piece of hope, maybe with UI about what arrow means)

\+ solo UI elements

Party

Misfortunes (water, losing trail, blizzard …)

Places as images

Map

Non-modelled sickness and death (cholera, dysentary, x has died)

------

Saturday, 25 June 2016

Update: I’ve now managed to get navigation working perfectly it seems? (Starting to think it would be kind of cool to have the entire movement as a final constellation above you? (Or the last ten or so?)

**List**

Make meditation->constellation work (including design)

Consider the idea that time spent on a single place involves the “moon” passing from one extreme to the other and if you wait it out you get the constellation? (Every landscape would have to start with the same lighting)

Halo “emitted” from the shape meditated on?

Decide on torch on-ness (always versus toggled versus auto-toggled at ’night')

Consider a torch that’s activated at “night”? Or just can be turned on whenever? Or is just always on?

**FIXED IT BECAUSE I’M CLEZMER**ISSUE: Fading material doesn’t seem to work in Mac build?

------

Thursday, 23 June 2016

It’s Thursday evening. I have not advanced this especially far since Sunday though I understand a few more things now. The basic steps below (on Sunday) make a lot of sense to me still as things to do before going into full production. If I build it fairly gradually it should stay manageable, provided the basic navigation and meditation ideas work properly.

------

Sunday, 19 June 2016

Get the smallest possible version going. TODAY [edit, Thursday: HA HA HA HA HA] if you can.

Add two diorama scenes with same landscape

Add wagon wheel to one

Create Oregon Trail UI texture and add to other

Make it emissive

Add ability to look up and down as well as rotate around

Add stars

Add a test-constellation for the wagon-wheel

Add navigation between the scenes

Solve the constellation problem better

Try navigation where the grid is always present and “next” one fades in with a “constellation” link when you’re sufficiently aligned to go there

Add ability for wagon wheel constellation to appear after meditation (of a day’s length)

That is – stars are always there, activate lines at the right time

Make stars not visible during the day? Nor under the world? (Or is that kind of nice?) (Can’t be under the world right now with the skybox doing a kind of “sunset” thing though.)

Investigate procedural skybox stuff (simpler “solid colours” version?)

Smallest thing realisations:

Need to be able to easily scale 3D dialog/image objects with the texture size?

Need a specific material for the objects

Should objects glow while you look at them to indicate “progress"? bit cheesy? halo?

**NO BECAUSE REAL CONSTELLATIONS HAPPILY IGNORE VARIOUS STARS**Need a background to the constellations added so they don’t get surrounding stars that make it make less sense how they’re organised?

------

Saturday, 18 June 2016

5:37 PM

**Some thoughts on the Oregon Trail integration and its implications**

So I now have this excellent thing of making The Oregon Trail the underlying “mystic text” of the piece. The idea is that a specific playthrough of TOT will serve kind of as the “Ozymandias” of the environment – the vestiges of that playthrough and its tragedy as the historical setting, the things you encounter. In a way I guess you could see it as a kind of story of matyrdom? The actual mystical element will be about a kind of tour of these “holy” sites of a kind of pilgrimmage, right? These things are holy because they’re old and because we don’t entirely know what they represent – things become mystical and holy largely because we choose that for them over time, building up layers and layers of weird wavy meaning.

So the plan then is to play through the Trail a few times, and ideally I think the narrative involves them getting all the way to the final raft before drowning. Clearly we can have grave sites (as per the game), a classic mystical/holy site. I do a close reading of the specific play through (plausibly writing a kind of diary of events along with screenshots in support). (And actually the play through I already did made it to the raft, so that could easily count – I think two of the ‘children’ died...

The other big part of this and something suggested by Rilla is instead of having generic “computer UI” things in the game, to instead involve the UI of the Oregan Trail itself… so you not only have elements from the game in terms of diegetic stuff, but also pieces of interface lying around with information about locations or things that happened… you could have the grave but also the death announcement for example. Or a picture of a location like a holy image. It’s a bit thievy, but it makes total sense in terms of the game. The one loss I fear is that it won’t work as well in the emission category? But for all I know it’ll be BETTER. And it solves problems like working out what to write – I don’t have to invent any text at all in this case, just get the text from the game – either literally screenshotting or just taking the font/equivalent and generating the texts. Actually I guess this is an indication I might need to literally get the playthrough (with appropriate names) going properly. Is it too much to call the leader Ozymandias? [yes]

So there’s a nice mirroring of the trail and the path around the sites, two kinds of pilgrimmages/journeys. Except that I’m presenting the sites kind of at random, rather than laid out across the actual trail… I think that’s okay since I’m paying tribute to the game not the actual diegetic world of the game. That’s where some nice blurriness exists.

Big question totally unaddressed: constellations. I have had multiple ideas for this but they’re uniformly sort of tacked on. I guess the “best” one is still to have constellations representing the objects you find along the way and that there’s some kind of “discovery” trigger that makes the constellation appear up in the sky - fancy camera pan or whatever? There’s at least some sense of … something… mystical? Hmm, it’s kind of bullshitty.

There was also that idea that your path through the world would be a constellation above you, charting your journey… that’s considerably simpler and I can see more immediately how one might actually do it.

But one incredibly frustrating/weird thing is just that you CANNOT SEE THE FUCKING STARS in the normal view. So when do you look at them? Do I allow you to look up with the camera? No particular reason not to really. And I guess that’s nice in the sense that if they feel like stargazing so be it, and if not… no problem?

I like that attitude, fella.

------

Saturday, 18 June 2016

11:32 AM

Titles? What can I call this thing?

**Broken Leg**

**The River**

**Independence**

**It Was Up In The Mountains**

**The Trail / Trail**

**The Wagon / Wagon**

**...**

**Independence, MI MO**

**Independence, Missouri**

------

Saturday, 18 June 2016

11:02 AM

**Thinking about mysticism and narrative**

So I now have this idea of using The Oregon Trail as my kind of mystic setting/narrative element for the game. It’s a real “Western” after all. And then my game could be a retelling of a specific adventure through the Oregon Trail, including things like graves, snakes, rifles, bison, towns, chimney rock, river beds, the arrow in the river scene, etc. In other words there are “events” in the Oregon Trail that can be portrayed as kind of omens/monuments to the story of that journey...

So a process would be to play the game (preferably unsuccessfully?) taking note of what happens and spinning a narrative around it. An even weirder thing would be to propose that the adventurers were perhaps consulting the I Ching for example, in deciding what to do.

How would all this narrative be conveyed through? I have the various interface elements of course… and if they reflect a pre-existing journey then presumably they shouldn’t be interactive actually? Which takes away something from the game though? And I’m now worrying that in diorama view they won’t actually be legible? Or if they are it will have to be pretty minimal text. But probably that’s a good thing? And after all if we’re going for mysticism then the more vague the landscape turns out to be the better?

So that’s it then… you have artifacts in the world that refer to the game (the rock, the snake, the wheel, etc.) and UI elements that refer to the game (particularly announcements about dysentary, shopping interface perhaps, decision making… - these should be unchangeable I think, just OK clickable). And also at least some  I Ching artifacts in there to confuse matters? Add to the mysticism? Or is that… stupid? Maybe it should just be straight up the vestiges of a past Oregon journey? But is that “mystical enough”? If you put mystical music/sounds on it it could be? Plus the constellation thing… a constellation thing.

Alright. So there needs to be that playthrough to gather more data points of what the things would be. But really it’s the technical shit that’s crying out for some effort at this point sadly sadly. Oh so sadly. Oh god. Oh. God.

Oregon models:

Shop front

Another building front?

Wagon?

Ox (skeleton… bones…)

Rifle

Chimney rock

River bed

Arrow (from the river)

Raft (from the river - can you drown, could that be the ending?)

Gravestone (multiple, as many as five)

Boot(s)

Hat

Blood

Camp fire

Wagon wheel

Snake

++?

Flag?

Oregon UIs:

d

------

Friday, 17 June 2016 – Sunday, 19 June 2016

**To Dos**

Dioramascape

Tweak diorama high to be much flatter

Make a single landscape/dioramascape in Blender and put in Unity

Camera

Make it possible to rotate the camera around the diorama

Add actual code to control this with the mouse (or keys – later for controller thumbstick)

Add ability to rotate view upward as well (to some sort of limit)

Limit up/down tilt

Light

Disable sunlight when it reaches a specific angle (to avoid illuminating too much)

Make the sun move across the sky at a specified rate

Consider the issue of the sides of the diorama being illuminated well after the rest of the world isn't

https://unity3d.com/learn/tutorials/topics/graphics/realtime-global-illumination-daynight-cycle

Oregon Trail UI

Work out how to get Oregon trail text emissive and in game

Get an Oregon trail image in the game

Dialog box

**GOING TO** Reconsider everything and think about using Oregon Trail interface elements instead

**NO LONGER RELEVANT**Create a simple dialog box with text and two buttons (OK and Cancel) [just unity shapes I guess]

**NO LONGER RELEVANT**Place it in the scene

**NO LONGER RELEVANT**Make the buttons function

**ACTUALLY THEY WORK**Worry about emissive material

**LOOKS PRETTY COOL**Make an emissive surface like a dialog box and see what happens

Artifacts

Make a single model of an artifact in Blender and put it in Unity

Make artifacts:

Wagon wheel

Ox skeleton (or partial)

Tombstone (with chiseled text?)

Rifle

Boots

Hat

River arrow

Raft

Chimney rock

Independence rock?

Snake

Wagon (or partial)

Blood on the ground

(Matt’s) Shop front (and perhaps another building? A fort?)

Navigation

Create a second diorama and add working navigation arrows to both

Decide on separate scenes or not (nicer animation possible if not?)

Performance likely to be better if separate

Constellations/sky

Add the ability to draw/add a constellation to the sky

Consider a flash from the sky with a new constellation is added to help them realise it’s there

Consider issue of what counts enough to add an artifact’s constellation to the sky...

Perhaps sufficient “contemplation” (e.g. looking at it through a full day/night cycle!!!!)

Work out the skybox possibilities

Work out star possibilities

The particle field from tutorial was nice, but not clear that translates that well?

[Or it may…]

**LET THEM ROTATE VIEW UP**Concerned we can’t even SEE the sky in the first place thanks to angle down?

------

Friday, 17 June 2016

11:41 AM

**A consideration of practicalities**

Size

At 5x5 with every square populated you have 25 “things” to make

At 6x6 you’d have 36 (or you could have 11 blank and revert to 25)

Really you want a “reasonable” amount of desolation anyway

10x10 with 25 objects? (1:4)

8x8 with 16 objects? (1:4) 8x8 with 22 objects? (1:3)?

Reference

An option for the “content” is to reference various Westerns and Mystic Westerns? The hat for El Topo as an example of this. But also references in the text to those movies/ideas.

Scale

This is a larger general consideration: the difference in size between, say, an arrow and the façade of a build is enormous. If they’re true to scale the arrow(s) may be invisible or indistinct.

If things are not true to scale there’s more of a sense of museum/statue/monument which might be nice but could be totally confusing

Sound

This is an issue. I’m not good at it. But...

Wind of course (procedural wind from Game Studies was actually quite nice)

Some western-sounding music? Free from somewhere?

Or conceivably just some of those reverb-y notes/strums you get?

Perhaps when you locate an object? (Or each object has a note/strum/sound)

No avatar avoids a whole bunch of stuff.

Light

The UIs should be emissive on their own which I think will look good

Is it always nighttime? In which case everything is always moonlit? In which case it will essentially be greyscale which may not be what I want? But could also be nice...

But really I associate a Western with daytime harsh light (noon light).

The obvious thing here is to have realtime sun and get all the sweet-ass shadows rolling around actually. And maybe it accelerates through if a new constellation comes… an effect where time accelerates to night and the scene rotates (out of player control) to point at the

Or could be that we shift to nighttime when they discover a constellation element?

(What about the idea that the dialogs also are constellation elements? e.g. you click “OK” and get an OK constellation, or you set a number to 9 and get a 9 constellation… sounds like work through…)

Landscapes

Basically just some set of lowpoly terrain objects (probably don’t even need especially many,

just re-present them rotated). Shouldn’t be emphatic as the idea is for them to just serve as platforms.

Could be sufficiently tall to plunge down? (Fog?)

UI elements

Dialog boxes with text + one or more buttons (including possibly scrolling text)

Dialog boxes with text + loading bar (that only moves if you’re there)

Maybe the object stars only appear when you find them and do the thing?

Dialog boxes with text + slider/checkbox/radiobutton [settings]

Dialog boxes with text-entry/number entry/age entry/...

**Question**: texts? What is the writing and where does it come from? It seems like it should weave the artifacts into the story

Objects

Cowboys apparel/equipment:

**Hat**, **boot**, **gun**, holster

Animals:

**Snake**, **horse**, mountain lion,

Artifacts:

**Arrow(s)**, **train tracks**, façades of buildings (**saloon**, **jail cell** wall), **camp fire**, **blood**, poker table, **whiskey bottle**, **sheriff badge**,

Landscaping:

**The arch**, a **boulder**, **riverbed**, **watering hole**, **cactus**

**Question**: scale? Are these “really there” or weird artifacts from a game/movie?

**Question**: how the fuck am I, Pippin James Barr, going to model these in Blender?

LOW poly. The lowest of polys. Hope for the best. Some of them are totally unrealistic.

(Or stealing them from asset stores? But that’s a whole other concept and won’t work I think.)

**Thought**: constellation: another option is that each object represents a constellation in the sky that is activated when you look at the thing (for "long enough"?)

------

Friday, 17 June 2016

9:46 AM

**A brainstorm**

Time to think about Mystic Westerns? Is this my 15 minutes for today? I think it probably ought to be. Devote that much time to seeing if I can figure something out.

Okay so I’m writing about Mystic Western. There are just under two weeks to produce a game on that theme plus “constellations” if I want to enter it for the chance to be shown in Marfa, which seems like it would be really neat given my affection for that place. So it’s very appealing at some base level.

BUT. Next week is DRIFT and shortly after that finished J+M arrive. So it’s not like there’s a huge amount of available time for plowing through a game. ALTHOUGH it’s also true that J+M would be fine with me putting my head down for a project like this, especially given we will be headed to New York the next week. So it’s plausible to throw, say, a week of work at this?

It needs to be playable on Windows with a controller, which probably implied using Unity. Or conceivably Electron and JS or HaxeFlixel? My mind jumps toward Unity I think. It seems environmental in a way that makes sense? BUT it’s also true it would be way easier to do a large landscape-y thing in 2D (for me personally) if that were the kind of direction (and it’s where my mind goes). I do like the idea of continuing to learn Unity things though.

THE OTHER thing this project might be an opportunity for is to think-through-making about the Humble Originals project. If I could find some kind of form that I was interested in for a larger project and make a smaller version of it, I’d end up with my ‘vertical slice’ to send John and would be able to work through some of the potential kinks. So that seems like a good reason to push on the project a bit, because otherwise my inclination is to work on the *It is as if* game which has less bearing on HO.

BUT it’s important given the time constraints to think about the smallest possible interesting idea that could be Mystic Western-y and also Constellation-y and also somehow related to Humble Originals. Is that trying to cram too much into a single small project. I’d want it to be REALLY SMALL.

My current vague vision is of a western style endless landscape, possibly with mystic/unexplained objects (thinking about Ozymandias here) and then also diegetic UI elements, like dialog boxes. Actually they could be one and the same now that I think about it… whoa… like a dialog box half buried in the sand… and the dialog boxes (and other UIs) would tell the (mystic) story of the landscape or world that the player finds themselves in. That’s really appealing visually, though I don’t have a strong grasp yet. But think of the half-buried table from Post-Apocalyptic Abramovic Method Games… that kind of thing combined with the palette of v r 2 perhaps? (I don’t particularly want to work in greys again for a bit.)

Okay, this sounds a bit like a thing. I has visual elements I want/need: a desert + diegetic UI.

Constellation, funnily enough, makes me think of that Scheinderman paper? (Dynamic Home Finder, just looked it up. And of course that’s EXACTLY what real estate places do these days - though not quite as nicely with sliders etc.) Which makes me wonder if you could include the UI in the game somehow? The other constellation idea would be to have the UI elements (or some of them) control the night sky or do something to it. Or you could go simpler and just have multiple ‘scenes’ and have each one be beneath a separate constellation in the sky.

Which gets me to the question/idea of dioramas, which I find very appealing post Game Studies and having looked at Grimsfield. Makes me start to wonder about procedurally generated desert. With procedural placement of objects/ideas/UIs in the scene. And rotatable with arrows leading to other dioramas (ala Grimsfield + Jonathan’s script for Game Studies). I like that idea that you’re kind of in the desert and kind of not in the desert that that has. Oddly removed.

BUT there’s also something to be said for the first-person encounter with a dialog box buried in the sand? (But if so then the diorama/isolated chunks thing may not really work out quite so well?

AND is going procedural just fucking asking for trouble if we’re being honest? Like there’s probably some nightmarish wormhole involved.

But it’s hard not to like the buried dialog box concept. Would I really be able to shape a longer term experience of that without relying on something procedural? And otherwise aren’t you going to just end up breadcrumbing them toward some boring realisation which doesn’t feel like it connects with mysticism...

The I Ching etc. Procedural. Tea leaves. Procedural. Mysticism is vague and procedural, that’s how it works, right? Should probably involve “another agency” as well, right? Like they tend to involve a belief in the influence of some outside force/entity that arranges things and tried to communicate with you. With “dialog boxes” make a great deal of sense for. Ha ha.

Okay so if we imagine pursuing this we end up with

Diorama vs. first-person (vs. a capsule with a cowboy hat on?)

A desert (low poly yellow terrain)

Objects in the desert

Western objects: hat, gun, dead horse, pool of blood, arrow, rock formation, watering hole, cactus, boot, classic set building (“assets” from a western?)

Mystic objects: conceivably Ozymandias style things (heads, legs)

UI objects (also mystic):

Dialog box (with text and button(s))

Slider

Radio button

Checkbox

Loading/progress bars

“Star maps” ala Schneider

Maps?

Search/text input (canned input I suppose)

And that would be it. In the procedural version you have some number of objects and UI options and you place them according to an algorithm each time you render a scene (or could even pre-generate all the options in a 2D array, say). And the player then navigates these spaces, looks at the objects (rotating the diorama if it goes that way), looks at the UI elements and interacts with them (causing what to happen?)

An obvious/easy tie-together would be if each of the UI elements allowed you to activate a constellation in the sky. (How do you look at the sky if you’re in a diorama setting? Some kind of dome with the stars rendered to it? Or literally have little luminous objects up in the “sky” and draw lines between them? That may actually be “easier”. That would be an overall tidy packet. Then it would probably need an “ending” though of course. urgh. Or you could have indefinitely many ‘constellations’ that start getting drawn all over each other… that would be the “roguelike” version of it.

Issues for me

Modelling is not my strong suit, so if I need a lot of objects that will be a major problem.

There are undoubtable programming problems in here that will be nightmarish

Depending on “how procedural” would have to get fancy with UI elements and dynamic texts etc.

(Though that can be mitigated by specifying the length of texts, for instance)

Is it always night time to avoid confusions about shifting from day to night?

UI elements could be luminous which would be kind of beautiful? (Though in real time of course they can’t illuminate other things near them I don’t think… or not, it says in the documentation this can work in realtime, so maybe it can. That would look incredible I think.)

HOW TO KEEP THIS SIMPLE ENOUGH THAT I CAN ACTUALLY DO IT IN LIMITED-ASS TIME?

Currently I’m attracted to dioramas + UIs + western objects + navigation like Grimsfield (including getting “lost”) I think, in a limited space (e.g. 5x5 or something), with probably random constellations generated by interacting with the UI elements. (Note that it’s not necessarily the case that this has to have an ending… you could just wander around the spaces illuminating the constellations and that’s that… read the texts, wonder what any of it means (mystic mystic). Should I look at the I Ching or other mystic texts as some sort of source? The Ozymandias poem is a way to start as well – the idea that it’s about a ‘look upon my works ye mighty’ kind of affair, except it’s the aftermath of a western (possibly even a western “game”? with bits of script/dialog/design elements as part of the UIs? That would start losing the constellations?

(You could be drawing constellations through your movements actually… that would be kind of nice? How would you start and stop this? Should you have control? Or is the constellation just an ongoing trace of the constellation of your movements through the space? (Seems legit.))

Okay we have an idea. The big question is: realistic?

Take a break then think about that big question. (Note by the way that 5x5 MIGHT be small enough to hard code the experience… might not be worth the procedural question…. would require 25 scenes… like 12/13 split on western and mystic? (Could even literally refer to John Marsen if I wanted to be cute. But best not to.)

------

Thursday, 16 June 2016

9:02 PM

https://itch.io/jam/mysticwestern

Should I actually do this? They’re exhibiting some of the games at Marfa which would frankly be amazing and I would like that a lot. And I like the theme a lot… mystic westerns are weird and interesting, and their extra theme-y bit of “constellations” is nice too. So it seems plausible to be interested in making something.

Also there’s the idea of using it to semi-prototype an approach to the Humble Originals project. And also I have a buffer of games right now to take time out to do something weirder. Or not weirder but “out of character” perhaps. And it would be good for me.

So go brain, think about things… tomorrow.
