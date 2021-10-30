# CloudNineKeyboardMacroGenerator
Utiltity to create macros for Cloud Nine C989M Keyboard using a script

Usage: CloudNineKeyboardMacroGenerator.exe filename_without_extension script_in_quotes

Example: CloudNineKeyboardMacroGenerator.exe SUDO \"sudo su - `./ GetServiceId.sh`\\ntcsh\\nset prompt = '%/% '\\nbindkey - k up history - search - backward\\nbindkey - k down history - search - forward\\n\"

This example will create a file called SUDO.mac that will type out the follow for you.
sudo su - `./ GetServiceId.sh`
tcsh
set prompt = '%/% '
bindkey - k up history - search - backward
bindkey - k down history - search - forward
