# mk64-watcher


## Intro
MK64 Watcher (MK64W) is an application intended to be used with an emulated version of Mario Kart 64 (1996) for the Nintendo 64 console. MK64W monitors your gameplay for when a new record is set on a track, and automatically uploads it to the MK64 leaderboard website. No more manual uploading required!

Leaderboard Website: https://mk64-ad77f.web.app/

Please see the setup instructions section below for first-time setup.

## Features
* Monitor and auto-upload "Fastest Lap" for a given time-trial course.
* Monitor and auto-upload "Fastest Course Time" for a given time-trial course.
* More to come!

## Requirements
1. Download Project64 emulator, get version 3.0.1: 
    * https://www.pj64-emu.com/public-releases
2. Download the MK64 rom, (PAL version suggested, since it's easier):
    * https://wowroms.com/en/roms/nintendo-64/mario-kart-64-europe/24659.html

## Setup Instructions
Make sure you are running exactly this emulator and ROM above, if you run the USA or Japan version, your times will be different than the rest of the group.

1. Run the emulator at least once before starting the MK64 watcher.
2. Ensure that the config.txt file is in the same directory as the MK64-Watcher.exe
3. Configure the config.txt file, fill in the following fields, an example file is filled out:
    1. "username": Fill in the username you wish to use for the leaderboard website in the (case insensitive)
    2. "eep-path": this is the directory of your MK64 save file. Typically found in the /save/ directory where Project64 is installed. 
        * example: C:\Program Files (x86)\Project64 3.0\Save\MARIOKART64-SDFLKJSDF987987SDF\
        * NOTE- make sure you include the slash (\) at the end
    3. "eep-file": This is the actual save file in the above directory, the default name should work in most cases "MARIOKART64.eep"
    4. db-endpoint: Endpoint of the website, unless specified, leave this as default!
4. Run "mk64 watcher.exe", you should see a cmd window open that says "Watching for new records..."

Now, you can race, set a record, and it will automatically upload to the leaderboard website.  
Visit https://mk64-ad77f.web.app/ and see how badly you got rekt!

Enjoy!

## Version Changes
* 1.0: (07/06/2022) Deployed as an executable!
* 1.1: (07/06/2022) UserID no longer needed, just the username should work

