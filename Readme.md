Action Groups Extended.

License: GPL3

Kerbal Space Program mod that increases the number of action groups to 250 and allows in-flight editing.

==========================

Originally from @Diazo, original thread here: https://forum.kerbalspaceprogram.com/index.php?/topic/67235-122dec1016-action-groups-extended-250-action-groups-in-flight-editing-now-kosremotetech/

As usual, if @Diazo comes back, I will very gladly pass this back to him.  Until then, I'll keep it updated.

This mod now depends on and requires the ToolbarController mod, available here


This mod now depends on and requires the ClickThroughBlocker mod, available here: 


This mod now depends on and requires the SpaceTuxLibrary mod, available here: https://spacedock.info/mod/2210/SpaceTux Library

This mod respects career mode VAB/SPH progress and only shows unlocked action groups by default.

To override and always have all action groups available, find the KSP\GameData\Diazo\AGExt\AGExt.cfg file and change the "OverrideCareer" value to 1 (one) from 0 (zero). You can also use the new stock ActionGroupsAlwaysAvaialble option in-game, found under Custom Difficutly -> Advanced Options.

-Option to override Career Mode action groups lockout on low level buildings to use action groups immediately if desired (Disabled by default)

-Increase the number of action groups to 250

-Edit Actions in Flight.

-Name Action Groups on a per vessel basis, so you can remember what is assigned where

-Actions state can be color coded based on status. (Note this defaults to off.)

-Toggle monitoring allows visual feedback of actions that lack this, such as the "Inverted Steering" on a wheel.

-Supports saving actions to sub-assemblies

Mods aware of this mod and can activate all 250 action groups:

Auto Actions: Automatically activate action groups (and RCS/SAS) on launching a new vessel.

Smart Parts: Activate an action group on a time delay, or at a set altitude or a fuel tank being empty.

kOS Scriptable Autopilot System: Control your vessel with scripts to automate vessel control tasks. (kOS 15.6 or newer)

RemoteTech: Support for signal delay and RT's Flight Computer

 

How to edit actions in flight?

Right-click (not left-click) the AGX button in flight mode and select the 'Edit' button.

How to assign actions to non-number groups (Brakes/Gear/etc.)

On the Groups window, click the Other button.

Download

Github: Download latest version can be found here.
Spacedock: https://spacedock.info/mod/1685/Action Groups Extended
Available on CKAN
All releases are archived here if you are running an older KSP version.
Note that ModuleManager is a required dependency. (Click here to download.)

Full changelog here.

This mod is released under the GPL 3 license and source code is on GitHub.

List of supported partModules for toggle state monitoring is here.

 

Installation

The GameData folder inside the zip file is to be merged with the GameData folder in your KSP directory. The AGExt.dll should end up at KSPInstall\GameData\Diazo\AGext\AGext.dll

Toolbar support is included, but is optional. If Blizzy's toolbar is not installed, the AGX icon will appear on the stock toolbar instead.

Quick Start

http://i.imgur.com/HfbFNWZ.jpg

http://i.imgur.com/W7dKIgS.jpg

1) Assign an action:

-Click the part that contains the action, all parts in symmetry will be selected by default and show in the Selected Parts List. To change to another part, just click it, the parts list will clear itself and select the new parts if they are different. If the parts are the same they will be added to the list. Clicking on a part in the list removes just that part from the list. A Blue Cross will hover over parts currently selected, a Red X will show over a part when you mouse-over it's button in the list.

-Select the group you wish to assign the action to in the Groups Window.

-All actions available on the part will now show in the Actions List (below the selected parts list). Click on an action to assign it to the current action group. It will now show in the Actions window. Actions currently assigned to the currently selected action group will show in the Actions window and a small green X will indicate the parts these actions are assigned to.

-The clicked action will now show in the Actions window, note that actions appear for individual parts, if you had 4 parts listed in the Selected Parts list, 4 Actions will appear in the Actions window, one for each part.

2) Remove an action:

-Select the Action Group that has the action assigned in the Groups Window.

-Click the Action in the Actions Window, on mouse-over a red X will appear on the part containing the action so you can tell similar actions apart.

3) Name a Group:

-Click on the Group Name text box, this is a free-entry box for typing with the keyboard.

4) Change a keybind:

-Groups 1-10 are assigned to the 1-10 number keys to match the KSP defaults. Other groups have no key assigned by default.

-Click on the Keybind Key ("Alpha1" in the above image), a new window showing all available keys will pop-up. Click the button representing the key you wish to assign. Assigning the key by pressing the physical key on the keyboard does not work.

5) Activate group in flight:

-Press the assigned key on the keyboard or click the action group on the Flight window.

-The Flight window can be shown/hidden by Left-Clicking the AGX icon on the toolbar. (Right-Clicking the AGX icon opens the menu.)

KeySets

The purpose of keysets is to make the most of your keyboard keys while avoiding conflicts. A typical use would be:

Mothership: Uses action groups 1 through 10 for it's actions.
Lander that docks to the mothership: Uses action groups 11 through 20 for it's actions to avoid conflicts while docked so you don't activate actions on both the mothership and lander by activating one action group.
and the keysets would be:

Keyset 1: Bind keyboard keys 1 through 10 to action groups 1 through 10 for use while flying the mothership.
Keyset 2: Bind keyboard keys 1 through 10 to action groups 11 through 20 for use while flying the lander.
This way, you can swap key sets with a couple mouse clicks (if fact, if you set the keyset on the lander before docking, it will remember it when you undock). By swapping the keysets, you "increase" your available keys on the keyboard you can use for actions.

KeySets are assignable to a sub-ship and change depending on which is in control and how they would work in your situation is as follows:

KeySet1: Keys 1 through 10 activate groups 1 through 10. (Default, the keyset all your ships are currently using.)
KeySet2: Keys 1 through 10 activate groups 11 though 20. (You would have to set this up.)
Then assign the actions you want to activate in group 3 on the first ship to group 3 and group 13 on the second ship. Then assign KeySet1 to the first ship and KeySet2 to the second ship.

Now, when you press the 3 key it activates either group 3 or 13 depending on which sub-ship has control and is automatic once you get the KeySets setup on the appropriate sub-ships.

If you want to experiment the KeySets are accessed by the button in the bottom right of the main window, it displays "KeySet1" by default as the first keyset is that.

Full AGC Manual on Github

Great review by @Kottabos:

https://youtu.be/XjirSGke1IM
