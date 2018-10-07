/*
!n::Run Notepad ; Alt+n
^n::Run Notepad ; Ctrl+n
+n::Run Notepad ; Shift+n
#n::Run Notepad ; Win+n
*/

global incvalue := 0
global filename := "xRageMeme"

Numpad0::PrintMouseCoords()
Numpad1::PrintIndex()
Numpad5::ExitApp
Numpad8::AutomateOneAndIncrement()
Numpad9::DoAll50Lol()

^Up::CurrentImageNamePaste()
^Right::IncreaseIncrement()
^Left::DecreaseIncrement()
^Down::ClickUploadEmoji()

DoAll50Lol()
{
Loop 49
{
ClickUploadEmoji()
Sleep, 500
CurrentImageNamePaste()
IncreaseIncrement()
Sleep, 500
}


}

AutomateOneAndIncrement()
{
ClickUploadEmoji()
Sleep, 500
CurrentImageNamePaste()
IncreaseIncrement()
}

PrintIndex()
{
MsgBox, %incvalue%

}

ClickUploadEmoji()
{
/*
requires chrome browser, 125% zoom
*/
MouseClick, left, 1405, 224

}

CurrentImageNamePaste() {
Clipboard = %filename%%incvalue%.jpg
Send ^v
Send {Enter}


}

PrintMouseCoords() {
MouseGetPos, xPos, yPos

MsgBox, %xPos% %yPos%

}

IncreaseIncrement() {
incvalue := incvalue + 1


}
DecreaseIncrement() {
incvalue := incvalue - 1

}

