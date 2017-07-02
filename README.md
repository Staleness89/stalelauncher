# staleLauncher
The launcher that I done made.
It starts/stops TC worldserver and authserver processes. Also launches the client if configued. Made for use with a single server, and server/client paths are configured in an XML file (staleConfig.xml). Includes options such as:
-Tray icon with shortcuts to launch each process.
-Delete client cache folder on launch
-Hide server processes
-Restart server on crash/exit
-Clear DBErrors.log on server start
-Shortcuts to server and client folders

This is my first attempt at a c# windows form type thing and was hastily done in a two or three days, so there might be improvements needed. I was unsatisfied with the options available for server controls, so I done made this simple little launcher.