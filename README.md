# If you came from YouTube...
I decided not to put up PPT Voice Organizer as introduced in [this video](https://www.youtube.com/watch?v=lmLvdla_hSw), because that tool was mostly meant to help me match speakers with their lines, and there's no point for you to repeat that work.

Instead, I am publishing the result of my work, the speakers of all 3,083 lines spoken in Puyo Puyo Tetris, as seen in [names.json](https://github.com/macmillan333/ppt-voice-sorter/blob/master/PPTVoiceSorter/PPTVoiceSorter/Resources/names.json). I think this still violates the game's EULA, but since I'm not publishing the transcript itself or any voice clip, I think it's quite unlikely that I'll get into trouble for this.

To make this name list useful to you, I wrote this tool, PPT Voice Sorter, that you are seeing here. It basically only does the "Export" part of PPT Voice Organizer.

BTW macmillan333 and DJ Hitori are two personas of the same person.
# PPT Voice Sorter
The tool that extracts all voice clips and transcripts from Puyo Puyo Tetris, and then sorts them by speaker. Only supports Windows at this time.

How to use:

1. Install a copy of Puyo Puyo Tetris on your PC.
2. Download unxwb from [here](http://aluigi.altervista.org/papers/unxwb.zip).
3. Download Puyo Text Editor from [here](https://github.com/nickworonekin/puyo-text-editor/releases).
4. Download PPT Voice Sorter from [here](https://github.com/macmillan333/ppt-voice-sorter/releases).
5. Launch PPT Voice Sorter, provide it with whatever it asks for, and click "Start".
6. If the tool works successfully, you will see subfolders in the destination folder you picked. Each subfolder corresponds to one character, contains all voice clips that character said, and contains one TXT file holding that character's transcript.

If the tool doesn't work for you:

* I don't know unxwb or Puyo Text Editor too well, but I suggest that you unzip each of those two into their own folder, and don't touch them.
* "Puyo Puyo Tetris" folder should be named "PuyoPuyoTetris", and should contain a "puyopuyotetris.exe". Make sure to not choose a folder above or below that.
* It might help to completely clear out the destination folder before clicking "Start". Or just create a new folder for this.
* If you still have an issue, click the "Issues" tab at the top of this page, create a new issue, and describe your problem in as much detail as possible. If the tool pops up a really lengthy error at you, you can hit Ctrl-C in that pop up to copy the error message, and paste it into your issue, and that would be helpful to me.
